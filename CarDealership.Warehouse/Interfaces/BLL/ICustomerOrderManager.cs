using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICustomerOrderManager
{
	Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status);
	Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate);
	Task<WarehouseCustomerOrderInfo> CreateCustomerOrderCarDealershipAsync(WarehouseCarDealershipCustomerOrderCreate warehouseCustomerOrderCreate);
	Task<WarehouseCustomerOrder> EditCustomerOrderByIdAsync(string customerOrderId, WarehouseCustomerOrderEdit customerOrderEdit);
	Task<WarehouseCustomerOrderInfo> EditCustomerOrderCarDealershipIdAsync(string carDealershipOrderId, WarehouseCustomerOrderEdit customerOrderEdit);
	Task<WarehouseCustomerOrder> CompletedCustomerOrderByIdAsync(string customerOrderId);
	Task<WarehouseCustomerOrder> CanceledCustomerOrderByIdAsync(string warehouseCustomerOrderId);
	Task CanceledCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId);
	Task DeleteCustomerOrderAsync(string customerOrderId);
}