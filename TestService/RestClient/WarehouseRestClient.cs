using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.RestClient;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TestService.Interface;

namespace TestService.RestClient;

public class WarehouseRestClient : BaseRestClient, IWarehouseRestClient
{
	public WarehouseRestClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
		: base(configuration, "Warehouse", httpClientFactory)
	{
	}

	
}
