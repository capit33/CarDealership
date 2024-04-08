using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.DTO;
using CarDealership.Infrastructure.RestClient;
using CarDealership.PersonsAdministration.Interfaces.RestClients;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.RestClients;

public class CarDealershipRestClient : BaseRestClient, ICarDealershipRestClient
{
	public CarDealershipRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
		: base(configuration, "CarDealership", httpClientFactory)
	{

	}

	public async Task<SearchResult> FindCustomerIdAsync(string customerId)
	{
		return await GetAsync<SearchResult>($"customer/{customerId}");
	}

	public async Task<SearchResult> FindEmployeeIdAsync(string employeeId)
	{
		return await GetAsync<SearchResult>($"employee/{employeeId}");
	}
}
