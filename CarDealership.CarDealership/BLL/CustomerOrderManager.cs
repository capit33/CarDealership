using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.CarDealership.Interfaces.MessageBroker;
using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Collections.Generic;
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

	public Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(string status)
	{
		throw new System.NotImplementedException();
	}

	public Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrderCreate customerOrderCreate)
	{
		throw new System.NotImplementedException();
	}

	public Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit)
	{
		throw new System.NotImplementedException();
	}

	public Task<CustomerOrder> EditCustomerOrderEmployeeIdAsync(string customerOrderId, string employeeId)
	{
		throw new System.NotImplementedException();
	}

	public Task<CustomerOrder> CanceledCustomerOrderAsync(string customerOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		throw new System.NotImplementedException();
	}
}
