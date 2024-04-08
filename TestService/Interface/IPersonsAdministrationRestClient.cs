using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.Filters;
using System.Threading.Tasks;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;

namespace TestService.Interface;

public interface IPersonsAdministrationRestClient
{
	Task<Customer> GetCustomerByIdAsync(string customerId);
	Task<PageItems<Customer>> GetCustomerByFilterAsync(CustomerFilter customerFilter);
	Task<Customer> CreateCustomerAsync(Customer customer);
	Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit);
	Task<Customer> RestoreCustomerAsync(string customerId);
	Task RemoveCustomerAsync(string customerId);
	Task DeleteCustomerAsync(string customerId);

	Task<Employee> GetEmployeeByIdAsync(string employeeId);
	Task<PageItems<Employee>> GetEmployeeByFilterAsync(EmployeeFilter employeeFilter);
	Task<Employee> CreateEmployeeAsync(Employee employee);
	Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit);
	Task<Employee> RestoreEmployeeAsync(string employeeId);
	Task RemoveEmployeeAsync(string employeeId);
	Task DeleteEmployeeAsync(string employeeId);
}