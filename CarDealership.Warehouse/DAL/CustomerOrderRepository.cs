using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class CustomerOrderRepository : BaseMongoRepository<WarehouseCustomerOrder>, ICustomerOrderRepository
{
	public CustomerOrderRepository(IConfiguration configuration) 
		: base(configuration, "warehouseCustomerOrder")
	{
	}

	public Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseCustomerOrder> GetCustomerOrderByCarIdAsync(string carId)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseCustomerOrder> GetCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<List<WarehouseCustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrder customerOrder)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseCustomerOrder> EditCustomerOrderAsync(string id, WarehouseCustomerOrderEdit customerOrderEdit)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseCustomerOrder> CustomerOrderChangeStatusByIdAsync(string customerOrderId, DocumentStatus canceled)
	{
		throw new System.NotImplementedException();
	}

	public Task DeleteCustomerOrderByIdAsync(string customerOrderId)
	{
		throw new System.NotImplementedException();
	}
}
