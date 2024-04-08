using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface IPurchaseOrderRepository
{
	Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId);
	Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(DocumentStatus documentStatus);
	Task<WarehousePurchaseOrder> GetPurchaseOrderBySupplierOrderIdAsync(string supplierOrderId);
	Task<WarehousePurchaseOrder> GetPurchaseOrderByCarDealershipIdAsync(string carDealershipOrderId);
	Task<WarehousePurchaseOrder> CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder);
	Task<WarehousePurchaseOrder> EditPurchaseOrderStatusAsync(string purchaseOrderId, DocumentStatus documentStatus);
	Task DeletePurchaseOrderAsync(string purchaseOrderId);
}