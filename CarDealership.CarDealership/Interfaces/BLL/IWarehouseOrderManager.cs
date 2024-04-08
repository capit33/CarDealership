using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL
{
	public interface IWarehouseOrderManager
	{
		Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId);
		Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(string status);
		Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrderCreate warehouseOrderCreate);
		Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId);
		Task<WarehouseOrder> CanceledWarehouseOrderAsync(string warehouseOrderId);
		Task WarehouseNotifyOrderStatusChangedAsync(string warehouseOrderId, DocumentStatus documentStatus);
		Task DeleteWarehouseOrderAsync(string warehouseOrderId);
	}
}