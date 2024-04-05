using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;

namespace CarDealership.Warehouse.DAL;

public class CarWarehouseRepository : BaseMongoRepository<CarFile>, ICarWarehouseRepository
{
	public CarWarehouseRepository(IConfiguration configuration) 
		: base(configuration, "carWarehouse")
	{

	}

}
