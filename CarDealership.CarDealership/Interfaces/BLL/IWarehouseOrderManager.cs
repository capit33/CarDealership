using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL
{
	public interface IWarehouseOrderManager
	{
		Task<object> CanceledWarehouseOrderAsync(string warehouseOrderId);
		Task<object> CreateWarehouseOrderAsync(WarehouseOrderCreate warehouseOrderCreate);
		Task DeleteWarehouseOrderAsync(string warehouseOrderId);
		Task<object> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId);
		Task<object> GetWarehouseOrderByIdAsync(string warehouseOrderId);
		Task<object> GetWarehouseOrdersByStatusAsync(string status);
	}
}