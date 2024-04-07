using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace CarDealership.CarDealership.RestClients;

public class WarehouseRestClient : BaseRestClient, IWarehouseRestClient
{
	public WarehouseRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory) 
		: base(configuration, "Warehouse", httpClientFactory)
	{
	}
}
