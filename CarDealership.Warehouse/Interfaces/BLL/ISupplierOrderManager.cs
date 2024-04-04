using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ISupplierOrderManager
{
	Task<object> ChangeSupplierOrderStutusAsync(string supplierOrderId, string status);
	Task<object> CreateSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<object> DeleteSupplierOrderAsync(string supplierOrderId);
	Task<object> EditSupplierOrderAsync(WarehouseSupplierOrderDTO supplierOrder);
	Task<object> GetSupplierOrderByIdAsync(string supplierOrderId);
}