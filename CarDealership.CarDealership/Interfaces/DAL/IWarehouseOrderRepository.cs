using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.DAL
{
	public interface IWarehouseOrderRepository
	{
		Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId);
		Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(DocumentStatus documentStatus);
		Task<WarehouseOrder> GetFirstEntryEmployeeIdAsync(string employeeOrderId);
		Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrder warehouseOrder);
		Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, Employee employee);
		Task<WarehouseOrder> EditWarehouseOrderStatusAsync(string warehouseOrderId, DocumentStatus canceled);
		Task DeleteWarehouseOrderAsync(string warehouseOrderId);
	}
}