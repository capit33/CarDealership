using CarDealership.Contracts.Model.Person.Customer;
using CarDealership.Infrastructure.Repository;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using Microsoft.Extensions.Configuration;

namespace CarDealership.PersonsAdministration.DAL;

public class CustomerRepository : BaseMongoRepository<Customer>, ICustomerRepository
{
	public CustomerRepository(IConfiguration configuration) : base(configuration, "customers")
	{
	}
}
