using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestService.Interface;

namespace TestService.RestClient;

public class CarDealershipRestClient : BaseRestClient, ICarDealershipRestClient
{
	public CarDealershipRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		: base(configuration, "CarDealership", httpClientFactory)
	{

	}

	public async Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		return await GetAsync<CustomerOrder>($"customer-order/{customerOrderId}");
	}

	public async Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(string status)
	{
		return await GetAsync<List<CustomerOrder>>($"customer-order/status/{status}");
	}

	public async Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrderCreate customerOrderCreate)
	{
		return await PostAsync<CustomerOrder, CustomerOrderCreate>($"customer-order", customerOrderCreate);
	}

	public async Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit)
	{
		return await PatchAsync<CustomerOrder, CustomerOrderEdit>($"customer-order", customerOrderEdit);
	}

	public async Task<CustomerOrder> CanceledCustomerOrderAsync(string customerOrderId)
	{
		return await PatchAsync<CustomerOrder>($"customer-order/canceled/{customerOrderId}");
	}

	public async Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		await DeleteAsync<object>($"customer-order/{customerOrderId}");
	}

	public async Task<SearchResult> FindCustomerIdAsync(string customerId)
	{
		return await GetAsync<SearchResult>($"search/customer/{customerId}");
	}

	public async Task<SearchResult> FindEmployeeIdAsync(string employeeId)
	{
		return await GetAsync<SearchResult>($"search/employee/{employeeId}");
	}

	public async Task<CarInfo> GetCarWarehouseByIdAsync(string carId)
	{
		return await GetAsync<CarInfo>($"warehouse/{carId}");
	}
	public async Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter)
	{
		return await PostAsync<PageItems<CarInfo>, CarFilter>($"warehouse/filter", carFilter);
	}

	public async Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId)
	{
		return await GetAsync<WarehouseOrder>($"warehouse-order/{warehouseOrderId}");
	}

	public async Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(string status)
	{
		return await GetAsync<List<WarehouseOrder>>($"warehouse-order/status /{status}");
	}

	public async Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrderCreate warehouseOrderCreate)
	{
		return await PostAsync<WarehouseOrder, WarehouseOrderCreate>($"warehouse-order", warehouseOrderCreate);
	}

	public async Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId)
	{
		return await PatchAsync<WarehouseOrder>($"warehouse-order/{warehouseOrderId}/employee/{employeeId}");
	}

	public async Task<WarehouseOrder> CanceledWarehouseOrderAsync(string warehouseOrderId)
	{
		return await PatchAsync<WarehouseOrder>($"canceled/{warehouseOrderId}");
	}

	public async Task DeleteWarehouseOrderAsync(string warehouseOrderId)
	{
		await DeleteAsync<WarehouseOrder>($"warehouse-order/{warehouseOrderId}");
	}
}
