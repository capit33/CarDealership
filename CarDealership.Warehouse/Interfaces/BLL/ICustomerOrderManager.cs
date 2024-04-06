using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICustomerOrderManager
{
	Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status);
	Task<WarehouseCustomerOrderInfo> CreateCustomerOrderAsync(WarehouseCustomerOrderCreate warehouseCustomerOrderCreate);
	Task<WarehouseCustomerOrder> ChangeCustomerOrderStatusAsync(string warehouseCustomerOrderId, string status);
	Task<WarehouseCustomerOrderInfo> ChangeCustomerOrderAsync(string carDealershipOrderId, WarehouseCustomerOrderEdit customerOrderEdit);
}