using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
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

	
}
