using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.DAL;

public interface ICustomerOrderRepository
{
	Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrder customerOrder);
	Task DeleteCustomerOrderByIdAsync(string id);
	Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit);
	Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus);
}