using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ISupplierOrderManager
{
	Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId);
	Task<List<WarehouseSupplierOrder>> GetSupplierOrderByStatusAsync(string status);
	Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<WarehouseSupplierOrder> ArrivalCarAsync(ArrivalCar arrivalCar);
	Task<WarehouseSupplierOrder> EditSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<WarehouseSupplierOrder> ChangeSupplierOrderStatusAsync(string supplierOrderId, string status);
	Task DeleteSupplierOrderAsync(string supplierOrderId);
}