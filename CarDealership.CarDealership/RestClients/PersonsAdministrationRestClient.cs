using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace CarDealership.CarDealership.RestClients;

public class PersonsAdministrationRestClient : BaseRestClient, IPersonsAdministrationRestClient
{
	public PersonsAdministrationRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
		: base(configuration, "PersonsAdministration", httpClientFactory)
	{
	}
}
