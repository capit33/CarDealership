using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.DAL
{
	public interface IWarehouseOrderRepository
	{
		Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId);
		Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(DocumentStatus documentStatus);
		Task<WarehouseOrder> GetFirstEntryEmployeeIdAsync(string employeeId);
		Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrder warehouseOrder);
		Task<WarehouseOrder> EditWarehouseOrderStatusAsync(string warehouseOrderId, DocumentStatus documentStatus);
		Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId);
		Task DeleteWarehouseOrderAsync(string warehouseOrderId);
	}
}