using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.RestClients;

public class WarehouseRestClient : BaseRestClient, IWarehouseRestClient
{
	public WarehouseRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
		: base(configuration, "Warehouse", httpClientFactory)
	{
	}

	public async Task<CarInfo> GetCarWarehouseByIdAsync(string carId)
	{
		return await GetAsync<CarInfo>($"client/car/{carId}");
	}

	public async Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter)
	{
		return await PostAsync<PageItems<CarInfo>, CarFilter>($"client/car/filter/", carFilter);
	}

	public async Task<WarehouseCustomerOrderInfo> CreateCustomerOrderAsync(
		WarehouseCarDealershipCustomerOrderCreate carDealershipCustomerOrderCreate)
	{
		return await PostAsync<WarehouseCustomerOrderInfo, WarehouseCarDealershipCustomerOrderCreate>
			($"client/customer-order/create", carDealershipCustomerOrderCreate);
	}

	public async Task<WarehouseCustomerOrderInfo> EditCustomerOrderAsync(string customerOrderId, 
		WarehouseCustomerOrderEdit warehouseCustomerOrderEdit)
	{
		return await PatchAsync<WarehouseCustomerOrderInfo, WarehouseCustomerOrderEdit>
			($"customer-order/edit/{customerOrderId}", warehouseCustomerOrderEdit);
	}

	public async Task CanceledWarehouseOrderAsync(string warehouseOrderId)
	{
		await PatchAsync<object>($"purchase-order/canceled/{warehouseOrderId}");
	}
}
