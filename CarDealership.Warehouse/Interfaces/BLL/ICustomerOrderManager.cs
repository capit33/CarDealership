using CarDealership.Contracts.Model.WarehouseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICustomerOrderManager
{
	Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<WarehouseCustomerOrder>> GetCustomerOrderByStatusAsync(string status);
	Task<WarehouseCustomerOrder> EditCustomerOrderStatusAsync(string customerOrderId, string status);
}