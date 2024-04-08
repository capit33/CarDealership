using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface ISupplierOrderRepository
{
	Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<WarehouseSupplierOrder>> GetSupplierOrdersByStatusAsync(DocumentStatus documentStatus);
	Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrder supplierOrder);
	Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId,
		ISupplierOrderEdit supplierOrderEdit = null, DocumentStatus? documentStatus = null);
	Task DeleteOrderAsync(string supplierOrderId);
}