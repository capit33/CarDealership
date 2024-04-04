using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Order;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ISupplierOrderManager
{
	Task<SupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<SupplierOrder>> GetSupplierOrderByStatusAsync(string status);
	Task<SupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<SupplierOrder> EditSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<SupplierOrder> ChangeSupplierOrderStatusAsync(string supplierOrderId, string status);
	Task DeleteSupplierOrderAsync(string supplierOrderId);
}