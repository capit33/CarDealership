using CarDealership.Contracts.Model.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface IPurchaseOrderManager
{
	Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId);
	Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(string status);
	Task DeletePurchaseOrderAsync(string purchaseOrderId);
	Task CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder);
}