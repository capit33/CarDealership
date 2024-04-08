using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestService.Interface;

public interface ICarDealershipRestClient
{
	Task<CustomerOrder> CanceledCustomerOrderAsync(string customerOrderId);
	Task<WarehouseOrder> CanceledWarehouseOrderAsync(string warehouseOrderId);
	Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrderCreate customerOrderCreate);
	Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrderCreate warehouseOrderCreate);
	Task DeleteCustomerOrderAsync(string customerOrderId);
	Task DeleteWarehouseOrderAsync(string warehouseOrderId);
	Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit);
	Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId);
	Task<SearchResult> FindCustomerIdAsync(string customerId);
	Task<SearchResult> FindEmployeeIdAsync(string employeeId);
	Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter);
	Task<CarInfo> GetCarWarehouseByIdAsync(string carId);
	Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(string status);
	Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId);
	Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(string status);
}