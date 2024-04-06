using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface ISupplierOrderRepository
{
	Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrder supplierOrder);
	Task DeleteOrderAsync(string supplierOrderId);
	Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrderEdit);
	Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<WarehouseSupplierOrder>> GetSupplierOrdersByStatusAsync(DocumentStatus documentStatus);
	Task<WarehouseSupplierOrder> SupplierOrderConfirmAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm);
	Task<WarehouseSupplierOrder> SupplierOrderStatusEditAsync(string supplierOrderId, DocumentStatus done);
}