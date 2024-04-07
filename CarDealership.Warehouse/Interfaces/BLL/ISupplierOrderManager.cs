using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ISupplierOrderManager
{
	Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<WarehouseSupplierOrder>> GetSupplierOrderByStatusAsync(string status);
	Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderCreate supplierOrder);
	Task<WarehouseSupplierOrder> CreateSupplierOrderFromPurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder);
	Task<WarehouseSupplierOrder> SupplierOrderProcessingAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm);
	Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrder);
	Task<WarehouseSupplierOrder> ArrivalCarAsync(string supplierOrderId, string VIN);
	Task<WarehouseSupplierOrder> CanceledSupplierOrderAsync(string supplierOrderId);
	Task DeleteSupplierOrderAsync(string supplierOrderId);
}