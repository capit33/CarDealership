using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TestService.Interface;

namespace TestService.RestClient;

public class PersonsAdministrationRestClient : BaseRestClient, IPersonsAdministrationRestClient
{
	public PersonsAdministrationRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		: base(configuration, "PersonsAdministration", httpClientFactory)
	{
	}

	public async Task<Customer> GetCustomerByIdAsync(string customerId)
	{
		return await GetAsync<Customer>($"customers/{customerId}");
	}

	public async Task<PageItems<Customer>> GetCustomerByFilterAsync(CustomerFilter customerFilter)
	{
		return await PostAsync<PageItems<Customer>, CustomerFilter>($"customers/filter", customerFilter);
	}

	public async Task<Customer> CreateCustomerAsync(Customer customer)
	{
		return await PostAsync<Customer, Customer>($"customers", customer);
	}

	public async Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit)
	{
		return await PatchAsync<Customer, CustomerEdit>($"customers/{customerId}", customerEdit);
	}

	public async Task<Customer> RestoreCustomerAsync(string customerId)
	{
		return await PatchAsync<Customer>($"customers/restore/{customerId}");
	}

	public async Task RemoveCustomerAsync(string customerId)
	{
		await PatchAsync<object>($"customers/remove/{customerId}");
	}

	public async Task DeleteCustomerAsync(string customerId)
	{
		await DeleteAsync<object>($"customers/{customerId}");
	}

	public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
	{
		return await GetAsync<Employee>($"employees/{employeeId}");
	}

	public async Task<PageItems<Employee>> GetEmployeeByFilterAsync(EmployeeFilter employeeFilter)
	{
		return await PostAsync<PageItems<Employee>, EmployeeFilter>($"employees/filter", employeeFilter);
	}

	public async Task<Employee> CreateEmployeeAsync(Employee employee)
	{
		return await PostAsync<Employee, Employee>($"employees", employee);
	}

	public async Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit)
	{
		return await PatchAsync<Employee, EmployeeEdit>($"employees/{employeeId}", employeeEdit);
	}

	public async Task<Employee> RestoreEmployeeAsync(string employeeId)
	{
		return await PatchAsync<Employee>($"employees/restore/{employeeId}");
	}

	public async Task RemoveEmployeeAsync(string employeeId)
	{
		await PatchAsync<Employee>($"employees/remove/{employeeId}");
	}
	public async Task DeleteEmployeeAsync(string employeeId)
	{
		await DeleteAsync<Employee>($"employees/{employeeId}");
	}
}
