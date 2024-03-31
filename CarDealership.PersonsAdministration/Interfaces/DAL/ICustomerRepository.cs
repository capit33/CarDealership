using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Customer;
using CarDealership.Contracts.Model.Person.Customer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.DAL
{
	public interface ICustomerRepository
	{
		Task<Customer> ChangeCustomerRemoveStatusAsync(string customerId, bool removeStatus);
		Task<Customer> CreateCustomerAsync(Customer customer);
		Task DeleteCustomerAsync(string customerId);
		Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit);
		Task<Customer> GetCustomerByIdAsync(string customerId);
		Task<long> GetCustomerCountByFilterAsync(CustomerFilter customerFilter);
		Task<List<Customer>> GetCustomersByFilterAsync(CustomerFilter customerFilter);
	}
}