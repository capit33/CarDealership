using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace CarDealership.CarDealership.DAL;

public class WarehouseOrderRepository
	: BaseMongoRepository<WarehouseOrder>, IWarehouseOrderRepository
{
	public WarehouseOrderRepository(IConfiguration configuration)
		: base(configuration, "warehouseOrder")
	{
	}
}
