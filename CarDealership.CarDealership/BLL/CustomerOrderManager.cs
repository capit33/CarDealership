using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.CarDealership.Interfaces.MessageBroker;
using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.BLL;

public class CustomerOrderManager : ICustomerOrderManager
{
	private IWarehouseManager WarehouseManager { get; }
	private ICustomerOrderRepository CustomerOrderRepository { get; }
	private IPersonsAdministrationRestClient PersonsAdministrationRestClient { get; }
	private IWarehouseRestClient WarehouseRestClient { get; }
	private ICustomerOrderStatusQueuePublisher CustomerOrderStatusQueuePublisher { get; }

	public CustomerOrderManager(IWarehouseManager warehouseManager,
		ICustomerOrderRepository customerOrderRepository,
		IPersonsAdministrationRestClient personsAdministrationRestClient,
		IWarehouseRestClient warehouseRestClient,
		ICustomerOrderStatusQueuePublisher customerOrderStatusQueuePublisher)
	{
		WarehouseManager = warehouseManager;
		CustomerOrderRepository = customerOrderRepository;
		PersonsAdministrationRestClient = personsAdministrationRestClient;
		WarehouseRestClient = warehouseRestClient;
		CustomerOrderStatusQueuePublisher = customerOrderStatusQueuePublisher;
	}

	public async Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);

		return await CustomerOrderRepository.GetCustomerOrderByIdAsync(customerOrderId);
	}

	public async Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(string status)
	{
		DocumentStatus documentStatus;

		if (!Enum.TryParse(status, true, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await CustomerOrderRepository.GetCustomerOrdersByStatusAsync(documentStatus);
	}

	public async Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrderCreate customerOrderCreate)
	{
		Helper.InputDataValidation(customerOrderCreate);

		var employee = await PersonsAdministrationRestClient.GetEmployeeByIdAsync(customerOrderCreate.EmployeeId);
		if (employee == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(employee), customerOrderCreate.EmployeeId));

		var customer = await PersonsAdministrationRestClient.GetCustomerByIdAsync(customerOrderCreate.CustomerId);
		if (customer == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(customer), customerOrderCreate.CustomerId));

		CarInfo carInfo = await WarehouseManager.GetCarWarehouseByIdAsync(customerOrderCreate.ReservedCarId);

		Helper.NullValidation(carInfo, customerOrderCreate.ReservedCarId);

		if (carInfo.InventoryStatus != InventoryStatus.Available)
			throw new InvalidOperationException(ConstantApp.CarNotAvailableError);

		var customerOrder = new CustomerOrder()
		{
			CustomerId = customer.Id,
			EmployeeId = employee.Id,
			ReservedCarId = carInfo.CarId,
			Car = (Car)carInfo,
			DocumentStatus = DocumentStatus.Processing,
			CreatedDate = DateTime.UtcNow
		};

		customerOrder = await CustomerOrderRepository.CreateCustomerOrderAsync(customerOrder);

		if (customerOrder == null)
			throw new Exception("Customer order not created");

		var carDealershipCustomerOrderCreate = new WarehouseCarDealershipCustomerOrderCreate()
		{
			CarDealershipOrderId = customerOrder.Id,
			CustomerFirstName = customer.FirstName,
			CustomerLastName = customer.LastName,
			ReservedCarId = customerOrder.ReservedCarId
		};

		// if car already reserved
		try
		{
			var warehouseCustomerOrderInfo = await WarehouseRestClient
				.CreateCustomerOrderAsync(carDealershipCustomerOrderCreate);
		}
		catch
		{
			await CustomerOrderRepository.DeleteCustomerOrderAsync(customerOrder.Id);
			throw;
		}

		return customerOrder;
	}

	public async Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit)
	{
		Helper.InputIdValidation(customerOrderId);
		Helper.InputDataValidation(customerOrderEdit);

		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		if (customerOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(customerOrder), customerOrderId));

		var warehouseCustomerOrderEdit = new WarehouseCustomerOrderEdit();

		if (customerOrderEdit.EmployeeId == customerOrder.EmployeeId)
			customerOrderEdit.EmployeeId = null;

		if (customerOrderEdit.EmployeeId != null)
		{
			var employee = await PersonsAdministrationRestClient.GetEmployeeByIdAsync(customerOrderEdit.EmployeeId);
			if (employee == null)
				throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(employee), customerOrderEdit.EmployeeId));
		}

		if (customerOrderEdit.CustomerId == customerOrder.CustomerId)
			customerOrderEdit.CustomerId = null;

		if (customerOrderEdit.CustomerId != null)
		{
			var customer = await PersonsAdministrationRestClient.GetCustomerByIdAsync(customerOrderEdit.CustomerId);
			if (customer == null)
				throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(customer), customerOrderEdit.CustomerId));

			warehouseCustomerOrderEdit.CustomerFirstName = customer.FirstName;
			warehouseCustomerOrderEdit.CustomerLastName = customer.LastName;
		}

		if (customerOrderEdit.ReservedCarId == customerOrder.ReservedCarId)
			customerOrderEdit.ReservedCarId = null;

		if (customerOrderEdit.ReservedCarId != null)
		{
			CarInfo carInfo = await WarehouseManager.GetCarWarehouseByIdAsync(customerOrderEdit.ReservedCarId);
			if (carInfo.InventoryStatus != InventoryStatus.Available)
				throw new InvalidOperationException(ConstantApp.CarNotAvailableError);

			warehouseCustomerOrderEdit.ReservedCarId = carInfo.CarId;
		}

		if (warehouseCustomerOrderEdit.IsObjectValid(out string _))
			await WarehouseRestClient.EditCustomerOrderAsync(customerOrderId, warehouseCustomerOrderEdit);

		if (customerOrderEdit.IsObjectValid(out string _))
			return await CustomerOrderRepository.EditCustomerOrderAsync(customerOrderId, customerOrderEdit);

		return customerOrder;
	}

	public async Task WarehouseNotifyOrderStatusChangedAsync(string customerOrderId, DocumentStatus documentStatus)
	{
		Helper.InputIdValidation(customerOrderId);

		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		if (customerOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(customerOrder), customerOrderId));

		await CustomerOrderRepository.EditCustomerOrderStatusAsync(customerOrderId, documentStatus);
	}

	public async Task<CustomerOrder> CanceledCustomerOrderAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);
		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		if (customerOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(customerOrder), customerOrderId));

		if (customerOrder.DocumentStatus == DocumentStatus.Canceled)
			return customerOrder;

		if (customerOrder.DocumentStatus == DocumentStatus.Done)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await CustomerOrderStatusQueuePublisher.SendMessage(new()
		{
			CarDealershipOrderId = customerOrder.Id,
			DocumentStatus = DocumentStatus.Canceled
		});

		return await CustomerOrderRepository.EditCustomerOrderStatusAsync(customerOrderId, DocumentStatus.Canceled);
	}

	public async Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);

		var customerOrder = await GetCustomerOrderByIdAsync(customerOrderId);

		if (customerOrder == null)
			return;

		if (customerOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageDeleteNotPossible(nameof(customerOrder.DocumentStatus),
					customerOrder.DocumentStatus.ToString()));

		await CustomerOrderRepository.DeleteCustomerOrderAsync(customerOrderId);
	}
}
