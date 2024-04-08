using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestService.Interface;

namespace TestService.RestClient;

public class WarehouseRestClient : BaseRestClient, IWarehouseRestClient
{
	public WarehouseRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		: base(configuration, "Warehouse", httpClientFactory)
	{
	}

	public async Task<CarFile> GetCarByIdAsync(string carId)
	{
		return await GetAsync<CarFile>($"car-warehouse/{carId}");
	}

	public async Task<CarInfo> GetCarInfoByIdAsync(string carId)
	{
		return await GetAsync<CarInfo>($"client/{carId}");
	}

	public async Task<List<CarInfo>> GetAvailableCarsAsync()
	{
		return await GetAsync<List<CarInfo>>($"car-warehouse/available");
	}

	public async Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter, string inventoryStatus = null)
	{
		return await PostAsync<PageItems<CarInfo>, CarFilter>($"car-warehouse/filter/status/{inventoryStatus}", carFilter);
	}

	public async Task<CarFile> CreateCarAsync(CarFileCreate carFileCreate)
	{
		return await PostAsync<CarFile, CarFileCreate>($"car-warehouse", carFileCreate);
	}

	public async Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit)
	{
		return await PatchAsync<CarFile, CarFileEdit>($"car-warehouse/{carId}", carFileEdit);
	}

	public async Task DeleteCarAsync(string carId)
	{
		await DeleteAsync<object>($"car-warehouse/{carId}");
	}

	public async Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		return await GetAsync<WarehouseCustomerOrder>($"customer-order/{customerOrderId}");
	}

	public async Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status)
	{
		return await GetAsync<List<WarehouseCustomerOrder>>($"customer-order/status/{status}");
	}

	public async Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		return await PostAsync<WarehouseCustomerOrder, WarehouseCustomerOrderCreate>($"customer-order", warehouseCustomerOrderCreate);
	}

	public async Task<WarehouseCustomerOrderInfo> CreateCustomerOrderCarDealershipAsync
		(WarehouseCarDealershipCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		return await PostAsync<WarehouseCustomerOrderInfo, WarehouseCarDealershipCustomerOrderCreate>
			($"client/customer-order/create", warehouseCustomerOrderCreate);
	}

	public async Task<WarehouseCustomerOrder> EditCustomerOrderByIdAsync(string customerOrderId,
		WarehouseCustomerOrderEdit customerOrderEdit)
	{
		return await PatchAsync<WarehouseCustomerOrder, WarehouseCustomerOrderEdit>($"customer-order/{customerOrderId}",
			customerOrderEdit);
	}

	public async Task<WarehouseCustomerOrderInfo> EditCustomerOrderCarDealershipIdAsync
		(string carDealershipOrderId, WarehouseCustomerOrderEdit customerOrderEdit)
	{
		return await PatchAsync<WarehouseCustomerOrderInfo, WarehouseCustomerOrderEdit>
			($"client/customer-order/edit/{carDealershipOrderId}", customerOrderEdit);
	}

	public async Task<WarehouseCustomerOrder> CompletedCustomerOrderByIdAsync(string customerOrderId)
	{
		return await PatchAsync<WarehouseCustomerOrder>($"customer-order/completed/{customerOrderId}");
	}

	public async Task<WarehouseCustomerOrder> CanceledCustomerOrderByIdAsync(string warehouseCustomerOrderId)
	{
		return await PatchAsync<WarehouseCustomerOrder>($"customer-order/canceled/{warehouseCustomerOrderId}");
	}

	public async Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		await DeleteAsync<object>($"customer-order/{customerOrderId}");
	}

	public async Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId)
	{
		return await GetAsync<WarehousePurchaseOrder>($"purchase-order/{purchaseOrderId}");
	}

	public async Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(string status)
	{
		return await GetAsync<List<WarehousePurchaseOrder>>($"purchase-order/status/{status}");
	}

	public async Task CanceledPurchaseOrderCarDealershipAsync(string carDealershipOrderId)
	{
		await PatchAsync<WarehouseCustomerOrderInfo>
			($"client/purchase-order/canceled/{carDealershipOrderId}");
	}

	public async Task DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		await GetAsync<object>($"purchase-order/{purchaseOrderId}");
	}

	public async Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId)
	{
		return await GetAsync<WarehouseSupplierOrder>($"supplier-order/{supplierOrderId}");
	}

	public async Task<List<WarehouseSupplierOrder>> GetSupplierOrderByStatusAsync(string status)
	{
		return await GetAsync<List<WarehouseSupplierOrder>>($"supplier-order/status/{status}");
	}

	public async Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderCreate supplierOrder)
	{
		return await PostAsync<WarehouseSupplierOrder, WarehouseSupplierOrderCreate>($"supplier-order", supplierOrder);
	}

	public async Task<WarehouseSupplierOrder> SupplierOrderProcessingAsync(string supplierOrderId, 
		SupplierOrderConfirm supplierOrderConfirm)
	{
		return await PatchAsync<WarehouseSupplierOrder, SupplierOrderConfirm>($"supplier-order/processing/{supplierOrderId}",
			supplierOrderConfirm);
	}

	public async Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, 
		WarehouseSupplierOrderEdit supplierOrderEdit)
	{
		return await PatchAsync<WarehouseSupplierOrder, WarehouseSupplierOrderEdit>($"supplier-order/{supplierOrderId}",
			supplierOrderEdit);
	}

	public async Task<WarehouseSupplierOrder> ArrivalCarAsync(string supplierOrderId, string VIN)
	{
		return await PatchAsync<WarehouseSupplierOrder>($"supplier-order/arrival-car/{supplierOrderId}/VIN/{VIN}");
	}

	public async Task<WarehouseSupplierOrder> CanceledSupplierOrderAsync(string supplierOrderId)
	{
		return await PatchAsync<WarehouseSupplierOrder>($"supplier-order/canceled/{supplierOrderId}");
	}

	public async Task DeleteSupplierOrderAsync(string supplierOrderId)
	{
		await DeleteAsync<WarehouseSupplierOrder>($"supplier-order/{supplierOrderId}");
	}
}
