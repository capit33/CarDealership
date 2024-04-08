using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.DAL;

public interface ICustomerOrderRepository
{
	Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId);
	Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus);
	Task<CustomerOrder> GetFirstEntryEmployeeIdAsync(string employeeOrderId);
	Task<CustomerOrder> GetFirstEntryCustomerIdAsync(string customerOrderId);
	Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrder customerOrder);
	Task DeleteCustomerOrderAsync(string customerOrderId);
	Task DeleteCustomerOrderByIdAsync(string id);
	Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit);
	Task<CustomerOrder> EditCustomerOrderStatusAsync(string customerOrderId, DocumentStatus canceled);
}