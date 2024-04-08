using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.DAL;

public interface ICustomerOrderRepository
{
	Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus);
	Task<CustomerOrder> GetFirstEntryEmployeeIdAsync(string employeeId);
	Task<CustomerOrder> GetFirstEntryCustomerIdAsync(string customerId);
	Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrder customerOrder);
	Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit);
	Task<CustomerOrder> EditCustomerOrderStatusAsync(string customerOrderId, DocumentStatus canceled);
	Task DeleteCustomerOrderAsync(string customerOrderId);
}