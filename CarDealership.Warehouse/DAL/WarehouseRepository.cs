using CarDealership.Contracts.Model.Warehouse;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;

namespace CarDealership.Warehouse.DAL;

public class WarehouseRepository : BaseMongoRepository<CarFile>, IWarehouseRepository
{
	public WarehouseRepository(IConfiguration configuration) : base(configuration, "carWarehouse")
	{

	}

}
