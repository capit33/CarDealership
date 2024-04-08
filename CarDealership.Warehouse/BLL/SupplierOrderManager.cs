using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Infrastructure;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.IO;
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
		Helper.InputIdValidation(supplierOrderId);

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

		Helper.InputDataValidation(supplierOrderCreate.Car);

		var carFile = await CarWarehouseManager.CreateCarByOrderAsync(supplierOrderCreate.Car);

		if (carFile == null || string.IsNullOrWhiteSpace(carFile.Id))
			throw new Exception("Car is not created");

		var supplierOrder = new WarehouseSupplierOrder()
		{
			CarFileId = carFile.Id,
			DocumentStatus = DocumentStatus.Created,
			CreatedDate = DateTime.UtcNow
		};
		return await SupplierOrderRepository.CreateSupplierOrderAsync(supplierOrder);
	}

	public async Task<WarehouseSupplierOrder> CreateSupplierOrderFromPurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder)
	{
		return await CreateSupplierOrderAsync(new WarehouseSupplierOrderCreate()
		{
			Car = purchaseOrder.Car,
		});
	}

	public async Task<WarehouseSupplierOrder> SupplierOrderProcessingAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm)
	{
		if (supplierOrderConfirm == null || string.IsNullOrWhiteSpace(supplierOrderConfirm.SupplierName))
			throw new InvalidDataException(nameof(supplierOrderConfirm));

		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(supplierOrder), supplierOrderId));

		if (supplierOrder.DocumentStatus != DocumentStatus.Created)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		supplierOrder = await SupplierOrderRepository.EditSupplierOrderProcessingAsync(supplierOrderId, supplierOrderConfirm);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Processing);
		return supplierOrder;
	}

	public async Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrderEdit)
	{
		if (supplierOrderEdit == null)
			throw new InvalidDataException(nameof(supplierOrderId));

		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(supplierOrder), supplierOrderId));

		if (supplierOrder.DocumentStatus != DocumentStatus.Created
			|| supplierOrder.DocumentStatus != DocumentStatus.Processing)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageEditNotPossible(nameof(supplierOrder.DocumentStatus), supplierOrder.DocumentStatus.ToString()));

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
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(supplierOrder), supplierOrderId));

		if (supplierOrder.DocumentStatus == DocumentStatus.Done
			|| supplierOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		var carFile = await CarWarehouseManager.CarArrivalAsync(supplierOrder.CarFileId, VIN);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(carFile), supplierOrder.CarFileId));

		supplierOrder = await SupplierOrderRepository.EditSupplierOrderStatusAsync(supplierOrderId, DocumentStatus.Done);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Done);
		return supplierOrder;
	}

	public async Task<WarehouseSupplierOrder> CanceledSupplierOrderAsync(string supplierOrderId)
	{
		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(supplierOrder), supplierOrderId));

		if (supplierOrder.DocumentStatus == DocumentStatus.Done
			|| supplierOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await CarWarehouseManager.DeleteCarAsync(supplierOrder.CarFileId);

		supplierOrder = await SupplierOrderRepository.EditSupplierOrderStatusAsync(supplierOrderId, DocumentStatus.Canceled);

		await ChangeOrderStatusManager.SupplierOrderStatusChanged(supplierOrder.Id, DocumentStatus.Canceled);

		return supplierOrder;
	}

	public async Task DeleteSupplierOrderAsync(string supplierOrderId)
	{
		var supplierOrder = await GetSupplierOrderByIdAsync(supplierOrderId);

		if (supplierOrder == null)
			return;

		if (supplierOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await SupplierOrderRepository.DeleteOrderAsync(supplierOrderId);
	}
}
