using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Infrastructure.Repository;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.DAL;

public class CustomerRepository : BaseMongoRepository<Customer>, ICustomerRepository
{
	public CustomerRepository(IConfiguration configuration) : base(configuration, "customers")
	{
	}

	public async Task<Customer> GetCustomerByIdAsync(string customerId)
	{
		return await Collection.Find(c => c.Id == customerId).SingleOrDefaultAsync();
	}

	public async Task<List<Customer>> GetCustomersByFilterAsync(CustomerFilter customerFilter)
	{
		var filter = FilterDefinition(customerFilter);
		var sort = Builders<Customer>.Sort.Ascending(e => e.LastName).Ascending(e => e.FirstName);

		return await Collection.Find(filter)
			.Sort(sort)
			.Skip(customerFilter.PageNumber * customerFilter.PageSize)
			.Limit(customerFilter.PageSize)
			.ToListAsync();
	}

	public async Task<long> GetCustomerCountByFilterAsync(CustomerFilter customerFilter)
	{
		var filter = FilterDefinition(customerFilter);
		return await Collection.CountDocumentsAsync(filter);
	}

	public async Task<Customer> CreateCustomerAsync(Customer customer)
	{
		customer.Id = ObjectId.GenerateNewId().ToString();
		await Collection.InsertOneAsync(customer);
		return await GetCustomerByIdAsync(customer.Id);
	}

	public async Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit)
	{
		var filter = Builders<Customer>.Filter.Where(c => c.Id == customerId);
		var update = UpdateDefinition(customerEdit);
		var options = new FindOneAndUpdateOptions<Customer, Customer>()
		{
			ReturnDocument = ReturnDocument.After
		};
		return await Collection.FindOneAndUpdateAsync(filter, update, options);
	}

	public async Task<Customer> ChangeCustomerRemoveStatusAsync(string customerId, bool removeStatus)
	{
		var filter = Builders<Customer>.Filter.Where(e => e.Id == customerId);
		var update = Builders<Customer>.Update.Set(e => e.IsRemove, removeStatus);
		var options = new FindOneAndUpdateOptions<Customer, Customer>()
		{
			ReturnDocument = ReturnDocument.After
		};

		return await Collection.FindOneAndUpdateAsync(filter, update, options);
	}

	public async Task DeleteCustomerAsync(string customerId)
	{
		await Collection.DeleteOneAsync(c => c.Id == customerId);
	}

	private FilterDefinition<Customer> FilterDefinition(CustomerFilter customerFilter)
	{
		var filters = new List<FilterDefinition<Customer>>();

		if (!string.IsNullOrWhiteSpace(customerFilter.FirstName))
			filters.Add(Builders<Customer>.Filter
					.Where(c => c.FirstName.ToLowerInvariant().Contains(customerFilter.FirstName.ToLowerInvariant())));

		if (!string.IsNullOrWhiteSpace(customerFilter.LastName))
			filters.Add(Builders<Customer>.Filter
					.Where(c => c.LastName.ToLowerInvariant().Contains(customerFilter.LastName.ToLowerInvariant())));

		if (customerFilter.IsRemove != null)
			filters.Add(Builders<Customer>.Filter
					.Where(e => e.IsRemove == customerFilter.IsRemove));

		if (filters.Any())
			return Builders<Customer>.Filter.And(filters);
		return Builders<Customer>.Filter.Empty;
	}

	private UpdateDefinition<Customer> UpdateDefinition(CustomerEdit customerEdit)
	{
		var updates = new List<UpdateDefinition<Customer>>();

		if (customerEdit.FirstName != null)
			updates.Add(Builders<Customer>.Update.Set(c => c.FirstName, customerEdit.FirstName));
		if (customerEdit.LastName != null)
			updates.Add(Builders<Customer>.Update.Set(c => c.LastName, customerEdit.LastName));

		return Builders<Customer>.Update.Combine(updates);
	}
}
