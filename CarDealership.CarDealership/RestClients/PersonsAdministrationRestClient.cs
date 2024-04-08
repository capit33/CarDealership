using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.RestClients;

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

	public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
	{
		return await GetAsync<Employee>($"employees/{employeeId}");
	}
}
