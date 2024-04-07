using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace CarDealership.CarDealership.DAL;

public class CustomerOrderRepository : BaseMongoRepository<CustomerOrder>, ICustomerOrderRepository
{
	public CustomerOrderRepository(IConfiguration configuration) 
		: base(configuration, "customerOrder")
	{
	}
}
