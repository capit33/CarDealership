using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface IPurchaseOrderRepository
{
	Task DeletePurchaseOrderAsync(string purchaseOrderId);
	Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId);
	Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStutusAsync(DocumentStatus documentStatus);
}