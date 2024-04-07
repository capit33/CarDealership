using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface IPurchaseOrderRepository
{
	Task<WarehousePurchaseOrder> GetPurchaseSupplierIdAsync(string supplierOrderId);
	Task<WarehousePurchaseOrder> GetPurchaseOrderByCarDealershipIdAsync(string purchaseOrderId);
	Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId);
	Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(DocumentStatus documentStatus);
	Task CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder);
	Task EditPurchaseOrderStatusAsync(string purchaseOrderId, DocumentStatus status);
	Task DeletePurchaseOrderAsync(string purchaseOrderId);
}