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

public class CustomerOrderManager : ICustomerOrderManager
{
	private ICarWarehouseManager CarWarehouseManager { get; }
	private IChangeOrderStatusManager ChangeOrderStatusManager { get; }
	private ICustomerOrderRepository CustomerOrderRepository { get; }

	public CustomerOrderManager(ICarWarehouseManager carWarehouseManager,
		IChangeOrderStatusManager changeOrderStatusManager,
		ICustomerOrderRepository customerOrderRepository)
	{
		CarWarehouseManager = carWarehouseManager;
		ChangeOrderStatusManager = changeOrderStatusManager;
		CustomerOrderRepository = customerOrderRepository;
	}

	public async Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		if (string.IsNullOrWhiteSpace(customerOrderId))
			throw new ArgumentNullException(nameof(customerOrderId));

		return await CustomerOrderRepository.GetCustomerOrderByIdAsync(customerOrderId);
	}

	public async Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status)
	{
		DocumentStatus documentStatus;
		if (!Enum.TryParse(status, true, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await CustomerOrderRepository.GetCustomerOrdersByStatusAsync(documentStatus);
	}

	public async Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		if (warehouseCustomerOrderCreate == null)
			throw new ArgumentNullException(nameof(warehouseCustomerOrderCreate));

		var customerOrder = await CreateCustomerOrderModel(warehouseCustomerOrderCreate);

		customerOrder = await CustomerOrderRepository.CreateCustomerOrderAsync(customerOrder);
		if (customerOrder == null)
			throw new Exception("Customer order not created.");

		await CarWarehouseManager.CarReservationAsync(customerOrder.ReservedCarId);

		return customerOrder;
	}

	public async Task<WarehouseCustomerOrderInfo> CreateCustomerOrderCarDealershipAsync
		(WarehouseCarDealershipCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		if (warehouseCustomerOrderCreate == null)
			throw new Exception("WarehouseCustomerOrder is null.");

		if (string.IsNullOrWhiteSpace(warehouseCustomerOrderCreate.CarDealershipOrderId))
			throw new ArgumentNullException(nameof(warehouseCustomerOrderCreate.CarDealershipOrderId));

		var customerOrder = await CreateCustomerOrderModel(warehouseCustomerOrderCreate);
		customerOrder.CarDealershipOrderId = warehouseCustomerOrderCreate.CarDealershipOrderId;

		customerOrder = await CustomerOrderRepository.CreateCustomerOrderAsync(customerOrder);
		if (customerOrder == null)
			throw new Exception("Customer order not created.");

		await CarWarehouseManager.CarReservationAsync(customerOrder.ReservedCarId);

		return new WarehouseCustomerOrderInfo(customerOrder);
	}

	public async Task<WarehouseCustomerOrder> EditCustomerOrderByIdAsync(string customerOrderId, 
		WarehouseCustomerOrderEdit customerOrderEdit)
	{
		Helper.InputIdValidation(customerOrderId);
		Helper.InputDataValidation(customerOrderEdit);

		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);
		Helper.NullValidation(customerOrder, customerOrderId);

		return await EditCustomerOrderAsync(customerOrder, customerOrderEdit);
	}

	public async Task<WarehouseCustomerOrderInfo> EditCustomerOrderCarDealershipIdAsync(string carDealershipOrderId, 
		WarehouseCustomerOrderEdit customerOrderEdit)
	{
		Helper.InputIdValidation(carDealershipOrderId);
		Helper.InputDataValidation(customerOrderEdit);

		var customerOrder = await CustomerOrderRepository.GetCustomerOrderByCarDealershipIdAsync(carDealershipOrderId);
		Helper.NullValidation(customerOrder, carDealershipOrderId);

		customerOrder = await EditCustomerOrderAsync(customerOrder, customerOrderEdit);

		return new WarehouseCustomerOrderInfo(customerOrder);
	}

	public async Task<WarehouseCustomerOrder> CompletedCustomerOrderByIdAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);
		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		Helper.NullValidation(customerOrder, customerOrderId);

		if (customerOrder.DocumentStatus == DocumentStatus.Done
			|| customerOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		if (customerOrder.ReservedCarId == null)
			throw new ArgumentNullException(nameof(customerOrder.ReservedCarId));

		await CarWarehouseManager.CarSoldOutAsync(customerOrder.ReservedCarId);

		customerOrder = await CustomerOrderRepository.CustomerOrderChangeStatusByIdAsync(customerOrder.Id, DocumentStatus.Done);
		if (customerOrder == null)
			throw new Exception("Customer order is not edit.");

		await ChangeOrderStatusManager.CustomerOrderStatusChangeAsync(customerOrder, DocumentStatus.Done);

		return customerOrder;
	}

	public async Task<WarehouseCustomerOrder> CanceledCustomerOrderByIdAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);
		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		Helper.NullValidation(customerOrder, customerOrderId);

		customerOrder = await CanceledCustomerOrderAsync(customerOrder);
		if (customerOrder == null)
			throw new Exception("Customer order status is not changed.");

		await ChangeOrderStatusManager.CustomerOrderStatusChangeAsync(customerOrder, DocumentStatus.Canceled);
		return customerOrder;
	}

	public async Task CanceledCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId)
	{
		Helper.InputIdValidation(carDealershipOrderId);

		var customerOrder = await CustomerOrderRepository.GetCustomerOrderByCarDealershipIdAsync(carDealershipOrderId);
		Helper.NullValidation(customerOrder, carDealershipOrderId);

		if (customerOrder.DocumentStatus == DocumentStatus.Done
			|| customerOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await CanceledCustomerOrderAsync(customerOrder);
	}

	public async Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);
		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		Helper.NullValidation(customerOrder, customerOrderId);

		if (customerOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await CustomerOrderRepository.DeleteCustomerOrderByIdAsync(customerOrderId);
	}

	private async Task<WarehouseCustomerOrder> CreateCustomerOrderModel(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		if (warehouseCustomerOrderCreate == null)
			throw new ArgumentNullException(nameof(warehouseCustomerOrderCreate));

		if (!warehouseCustomerOrderCreate.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		var carFile = await CarWarehouseManager.GetCarByIdAsync(warehouseCustomerOrderCreate.ReservedCarId);

		Helper.NullValidation(carFile, warehouseCustomerOrderCreate.ReservedCarId);

		if (carFile.InventoryStatus != InventoryStatus.Available)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageEditNotPossible(nameof(carFile.InventoryStatus), carFile.InventoryStatus.ToString()));

		return new WarehouseCustomerOrder()
		{
			CustomerFirstName = warehouseCustomerOrderCreate.CustomerFirstName,
			CustomerLastName = warehouseCustomerOrderCreate.CustomerLastName,
			ReservedCarId = warehouseCustomerOrderCreate.ReservedCarId,
			DocumentStatus = DocumentStatus.Processing,
			CreatedDate = DateTime.UtcNow
		};
	}

	private async Task<WarehouseCustomerOrder> EditCustomerOrderAsync(WarehouseCustomerOrder customerOrder,
		WarehouseCustomerOrderEdit customerOrderEdit)
	{
		if (customerOrder == null)
			throw new ArgumentNullException(nameof(customerOrder));

		if (customerOrderEdit == null)
			throw new ArgumentNullException(nameof(customerOrderEdit));

		if (customerOrder.DocumentStatus == DocumentStatus.Done
			|| customerOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		if (customerOrderEdit.ReservedCarId != null
			&& customerOrder.ReservedCarId != customerOrderEdit.ReservedCarId)
		{
			await CarWarehouseManager.CarReservationAsync(customerOrderEdit.ReservedCarId);
			await CarWarehouseManager.CanceledCarReservationAsync(customerOrder.ReservedCarId);
		}

		customerOrder = await CustomerOrderRepository.EditCustomerOrderAsync(customerOrder.Id, customerOrderEdit);
		return customerOrder;
	}

	private async Task<WarehouseCustomerOrder> CanceledCustomerOrderAsync(WarehouseCustomerOrder customerOrder)
	{
		if (customerOrder == null)
			throw new ArgumentNullException(nameof(customerOrder));

		if (customerOrder.DocumentStatus == DocumentStatus.Done
			|| customerOrder.DocumentStatus == DocumentStatus.Canceled)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		if (customerOrder.ReservedCarId != null)
		{
			await CarWarehouseManager.CanceledCarReservationAsync(customerOrder.ReservedCarId);
		}

		customerOrder = await CustomerOrderRepository.CustomerOrderChangeStatusByIdAsync(customerOrder.Id, DocumentStatus.Canceled);
		return customerOrder;
	}
}
