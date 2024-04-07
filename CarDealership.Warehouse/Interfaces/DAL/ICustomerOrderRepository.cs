using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface ICustomerOrderRepository
{
	Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<WarehouseCustomerOrder> GetCustomerOrderByCarIdAsync(string carId);
	Task<WarehouseCustomerOrder> GetCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId);
	Task<List<WarehouseCustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus);
	Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrder customerOrder);
	Task<WarehouseCustomerOrder> EditCustomerOrderAsync(string id, WarehouseCustomerOrderEdit customerOrderEdit);
	Task<WarehouseCustomerOrder> CustomerOrderChangeStatusByIdAsync(string customerOrderId, DocumentStatus canceled);
	Task DeleteCustomerOrderByIdAsync(string customerOrderId);
}