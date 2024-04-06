using Amazon.Runtime.Endpoints;
using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Warehouse.DAL;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using MassTransit.Transports;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class SupplierOrderManager : ISupplierOrderManager
{
	private ICarWarehouseManager CarWarehouseManager { get; }
	private IChangeOrderStatusManager ChangeOrderStatusManager { get; }
	private ISupplierOrderRepository SupplierOrderRepository { get; }

	public SupplierOrderManager(ICarWarehouseManager carWarehouseManager, 
		IChangeOrderStatusManager changeOrderStatusManager, 
		ISupplierOrderRepository supplierOrderRepository)
	{
		CarWarehouseManager = carWarehouseManager;
		ChangeOrderStatusManager = changeOrderStatusManager;
		SupplierOrderRepository = supplierOrderRepository;
	}

	public async Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId)
	{
		if (string.IsNullOrWhiteSpace(supplierOrderId))
			throw new ArgumentNullException(nameof(supplierOrderId));

		return await SupplierOrderRepository.GetSupplierOrderByIdAsync(supplierOrderId);
	}

	public async Task<List<WarehouseSupplierOrder>> GetSupplierOrderByStatusAsync(string status)
	{
		DocumentStatus documentStatus;

		if (!Enum.TryParse(status, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await SupplierOrderRepository.GetSupplierOrdersByStatusAsync(documentStatus);
	}

	public async Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderCreate supplierOrderCreate)
	{
		if (supplierOrderCreate == null)
			throw new ArgumentNullException(nameof(supplierOrderCreate));

		if (supplierOrderCreate.Car == null)
			throw new ArgumentNullException(nameof(supplierOrderCreate.Car));

		if (!supplierOrderCreate.Car.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		var carFile = await CarWarehouseManager.CreateCarByOrderAsync(supplierOrderCreate.Car);

		if (carFile == null || string.IsNullOrWhiteSpace(carFile.Id))
			throw new InvalidDataException(ConstantApp.CarNotFindError);

		var supplierOrder = new WarehouseSupplierOrder()
		{
			CarFileId = carFile.Id,
			OrderStatus = DocumentStatus.Created,
			CreatedDate = DateTime.UtcNow
		};
		return await SupplierOrderRepository.CreateSupplierOrderAsync(supplierOrder);
	}

	public async Task<WarehouseSupplierOrder> SupplierOrderConfirmAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm)
	{
		if (supplierOrderConfirm  == null || string.IsNullOrWhiteSpace(supplierOrderConfirm.SupplierName))
			throw new InvalidDataException(nameof(supplierOrderConfirm));

		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.SupplierOrderNotFindError);

		if (supplierOrder.OrderStatus != DocumentStatus.Created)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		supplierOrder =  await SupplierOrderRepository.SupplierOrderConfirmAsync(supplierOrderId, supplierOrderConfirm);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Processing);
		return supplierOrder;
	}

	public async Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrderEdit)
	{
		if (supplierOrderEdit == null)
			throw new InvalidDataException(nameof(supplierOrderId));

		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.SupplierOrderNotFindError);

		if (supplierOrder.OrderStatus != DocumentStatus.Created 
			|| supplierOrder.OrderStatus != DocumentStatus.Processing)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageEditNotPossible(nameof(supplierOrder.OrderStatus), supplierOrder.OrderStatus.ToString()));

		var isOderEdit = !string.IsNullOrEmpty(supplierOrderEdit.SupplierName);
		var isCarEdit = supplierOrderEdit.CarEditing.IsObjectValid(out string errorMessage);

		if (!(isCarEdit || isOderEdit))
			throw new InvalidDataException(ConstantApp.NoFieldsToEdit);

		if (isOderEdit)
			await CarWarehouseManager.EditCarAsync(supplierOrder.CarFileId, supplierOrderEdit.CarEditing);

		if (isOderEdit)
			return await SupplierOrderRepository.EditSupplierOrderAsync(supplierOrderId, supplierOrderEdit);

		return supplierOrder;
	}

	public async Task<WarehouseSupplierOrder> ArrivalCarAsync(string supplierOrderId, string VIN)
	{
		if (string.IsNullOrWhiteSpace(VIN))
			throw new ArgumentNullException(nameof(VIN));

		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.SupplierOrderNotFindError);

		if (supplierOrder.OrderStatus == DocumentStatus.Done
			|| supplierOrder.OrderStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		var carFile = await CarWarehouseManager.CarArrivalAsync(supplierOrder.CarFileId, VIN);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.CarNotFindError);

		supplierOrder = await SupplierOrderRepository.SupplierOrderStatusEditAsync(supplierOrderId, DocumentStatus.Done);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Done);
		return supplierOrder;
	}

	public async Task<WarehouseSupplierOrder> CanceledSupplierOrderAsync(string supplierOrderId)
	{
		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.SupplierOrderNotFindError);

		if (supplierOrder.OrderStatus == DocumentStatus.Done
			|| supplierOrder.OrderStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await CarWarehouseManager.DeleteCarAsync(supplierOrder.CarFileId);

		supplierOrder = await SupplierOrderRepository.SupplierOrderStatusEditAsync(supplierOrderId, DocumentStatus.Canceled);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Canceled);
		return supplierOrder;
	}

	public async Task DeleteSupplierOrderAsync(string supplierOrderId)
	{
		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			return;

		if (supplierOrder.OrderStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await SupplierOrderRepository.DeleteOrderAsync(supplierOrderId);
	}
}
