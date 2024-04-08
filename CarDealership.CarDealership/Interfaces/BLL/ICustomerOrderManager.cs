using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL;

public interface ICustomerOrderManager
{
	Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(string status);
	Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrderCreate customerOrderCreate);
	Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit);
	Task<CustomerOrder> CanceledCustomerOrderAsync(string customerOrderId);
	Task DeleteCustomerOrderAsync(string customerOrderId);
	Task WarehouseNotifyOrderStatusChangedAsync(string carDealershipOrderId, DocumentStatus documentStatus);
}