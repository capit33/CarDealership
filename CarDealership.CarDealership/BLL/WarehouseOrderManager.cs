using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.CarDealership.Interfaces.MessageBroker;
using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.BLL;

public class WarehouseOrderManager : IWarehouseOrderManager
{
	private IWarehouseOrderRepository WarehouseOrderRepository { get; }
	private IWarehouseRestClient WarehouseRestClient { get; }
	private IPersonsAdministrationRestClient PersonsAdministrationRestClient { get; }
	private IPurchaseOrderQueuePublisher PurchaseOrderQueuePublisher { get; }

	public WarehouseOrderManager(IWarehouseOrderRepository warehouseOrderRepository,
		IWarehouseRestClient warehouseRestClient,
		IPersonsAdministrationRestClient personsAdministrationRestClient,
		IPurchaseOrderQueuePublisher purchaseOrderQueuePublisher)
	{
		WarehouseOrderRepository = warehouseOrderRepository;
		WarehouseRestClient = warehouseRestClient;
		PersonsAdministrationRestClient = personsAdministrationRestClient;
		PurchaseOrderQueuePublisher = purchaseOrderQueuePublisher;
	}

	public async Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId)
	{
		Helper.InputIdValidation(warehouseOrderId);

		return await WarehouseOrderRepository.GetWarehouseOrderByIdAsync(warehouseOrderId);
	}

	public async Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(string status)
	{
		DocumentStatus documentStatus;

		if (!Enum.TryParse(status, true, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await WarehouseOrderRepository.GetWarehouseOrdersByStatusAsync(documentStatus);
	}

	public async Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrderCreate warehouseOrderCreate)
	{
		if (warehouseOrderCreate == null)
			throw new ArgumentNullException(nameof(warehouseOrderCreate));

		if (warehouseOrderCreate.EmployeeId == null)
			throw new ArgumentNullException(nameof(warehouseOrderCreate.EmployeeId));

		Helper.InputDataValidation(warehouseOrderCreate.Car);

		var employee = await PersonsAdministrationRestClient.GetEmployeeByIdAsync(warehouseOrderCreate.EmployeeId);

		if (employee == null)
			throw new InvalidDataException(
				ConstantApp.GetNotFoundErrorMessage(nameof(employee), warehouseOrderCreate.EmployeeId));

		var warehouseOrder = new WarehouseOrder()
		{
			Car = warehouseOrderCreate.Car,
			EmployeeId = employee.Id,
			DocumentStatus = DocumentStatus.Created,
			CreatedDate = DateTime.UtcNow
		};

		warehouseOrder = await WarehouseOrderRepository.CreateWarehouseOrderAsync(warehouseOrder);

		if (warehouseOrder == null)
			throw new Exception("Warehouse Order not created.");

		await PurchaseOrderQueuePublisher.SendMessage(new()
		{
			OrderId = warehouseOrder.Id,
			Car = warehouseOrder.Car,
		});

		return warehouseOrder;
	}

	public async Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId)
	{
		Helper.InputIdValidation(warehouseOrderId, employeeId);

		var warehouseOrder = await GetWarehouseOrderByIdAsync(warehouseOrderId);

		if (warehouseOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(warehouseOrder), warehouseOrderId));

		if (warehouseOrder.EmployeeId == employeeId)
			return warehouseOrder;

		var employee = await PersonsAdministrationRestClient.GetEmployeeByIdAsync(employeeId);

		if (employee == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(employee), employeeId));

		return await WarehouseOrderRepository.EditWarehouseOrderEmployeeIdAsync(warehouseOrderId, employeeId);
	}

	public async Task WarehouseNotifyOrderStatusChangedAsync(string warehouseOrderId, DocumentStatus documentStatus)
	{
		Helper.InputIdValidation(warehouseOrderId);

		var warehouseOrder = await GetWarehouseOrderByIdAsync(warehouseOrderId);

		if (warehouseOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(warehouseOrder), warehouseOrderId));

		await WarehouseOrderRepository.EditWarehouseOrderStatusAsync(warehouseOrderId, documentStatus);
	}

	public async Task<WarehouseOrder> CanceledWarehouseOrderAsync(string warehouseOrderId)
	{
		Helper.InputIdValidation(warehouseOrderId);

		var warehouseOrder = await GetWarehouseOrderByIdAsync(warehouseOrderId);

		if (warehouseOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(warehouseOrder), warehouseOrderId));

		if (warehouseOrder.DocumentStatus != DocumentStatus.Created)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await WarehouseRestClient.CanceledWarehouseOrderAsync(warehouseOrderId);
		return await WarehouseOrderRepository.EditWarehouseOrderStatusAsync(warehouseOrderId, DocumentStatus.Canceled);
	}

	public async Task DeleteWarehouseOrderAsync(string warehouseOrderId)
	{
		Helper.InputIdValidation(warehouseOrderId);

		var warehouseOrder = await GetWarehouseOrderByIdAsync(warehouseOrderId);
		if (warehouseOrder == null)
			return;

		if (warehouseOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageDeleteNotPossible(nameof(warehouseOrder.DocumentStatus),
					warehouseOrder.DocumentStatus.ToString()));

		await WarehouseOrderRepository.DeleteWarehouseOrderAsync(warehouseOrderId);
	}
}
