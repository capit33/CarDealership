using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL
{
	public interface ICustomerOrderRepository
	{
		Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrder customerOrder);
		Task<WarehouseCustomerOrder> CustomerOrderChangeStatusByIdAsync(string id, DocumentStatus canceled);
		Task DeleteCustomerOrderByIdAsync(string customerOrderId);
		Task<WarehouseCustomerOrder> EditCustomerOrderAsync(string id, WarehouseCustomerOrderEdit customerOrderEdit);
		Task<WarehouseCustomerOrder> GetCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId);
		Task<WarehouseCustomerOrder> GetCustomerOrderByCarIdAsync(string carId);
		Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
		Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(DocumentStatus documentStatus);
	}
}