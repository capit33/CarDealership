using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestService.Interface;

public interface IWarehouseRestClient
{
	Task<CarFile> GetCarByIdAsync(string carId);
	Task<CarInfo> GetCarInfoByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter, string inventoryStatus = null);
	Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit);
	Task DeleteCarAsync(string carId);

	Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status);
	Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate);
	Task<WarehouseCustomerOrderInfo> CreateCustomerOrderCarDealershipAsync(WarehouseCarDealershipCustomerOrderCreate warehouseCustomerOrderCreate);
	Task<WarehouseCustomerOrder> EditCustomerOrderByIdAsync(string customerOrderId, WarehouseCustomerOrderEdit customerOrderEdit);
	Task<WarehouseCustomerOrderInfo> EditCustomerOrderCarDealershipIdAsync(string carDealershipOrderId, WarehouseCustomerOrderEdit customerOrderEdit);
	Task<WarehouseCustomerOrder> CompletedCustomerOrderByIdAsync(string customerOrderId);
	Task<WarehouseCustomerOrder> CanceledCustomerOrderByIdAsync(string warehouseCustomerOrderId);
	Task DeleteCustomerOrderAsync(string customerOrderId);

	Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId);
	Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(string status);
	Task CanceledPurchaseOrderCarDealershipAsync(string carDealershipOrderId);
	Task DeletePurchaseOrderAsync(string purchaseOrderId);

	Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<WarehouseSupplierOrder>> GetSupplierOrderByStatusAsync(string status);
	Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderCreate supplierOrder);
	Task<WarehouseSupplierOrder> SupplierOrderProcessingAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm);
	Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrder);
	Task<WarehouseSupplierOrder> ArrivalCarAsync(string supplierOrderId, string VIN);
	Task<WarehouseSupplierOrder> CanceledSupplierOrderAsync(string supplierOrderId);
	Task DeleteSupplierOrderAsync(string supplierOrderId);
}