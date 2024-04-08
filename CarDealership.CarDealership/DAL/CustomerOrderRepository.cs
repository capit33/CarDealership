using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using CarDealership.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.DAL;

public class CustomerOrderRepository : BaseMongoRepository<CustomerOrder>, ICustomerOrderRepository
{
	public CustomerOrderRepository(IConfiguration configuration)
		: base(configuration, "customerOrder")
	{
	}

	public async Task<CustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		return await Collection.Find(c => c.Id == customerOrderId).SingleOrDefaultAsync();
	}

	public async Task<List<CustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		return await Collection.Find(c => c.DocumentStatus == documentStatus).ToListAsync();
	}

	public async Task<CustomerOrder> GetFirstEntryCustomerIdAsync(string customerId)
	{
		return await Collection.Find(c => c.CustomerId == customerId).FirstOrDefaultAsync();
	}

	public async Task<CustomerOrder> GetFirstEntryEmployeeIdAsync(string employeeId)
	{
		return await Collection.Find(c => c.EmployeeId == employeeId).FirstOrDefaultAsync();
	}
	public async Task<CustomerOrder> CreateCustomerOrderAsync(CustomerOrder customerOrder)
	{
		customerOrder.Id = ObjectId.GenerateNewId().ToString();
		await Collection.InsertOneAsync(customerOrder);
		return await GetCustomerOrderByIdAsync(customerOrder.Id);
	}

	public async Task<CustomerOrder> EditCustomerOrderAsync(string customerOrderId, CustomerOrderEdit customerOrderEdit)
	{
		var filter = Builders<CustomerOrder>.Filter.Where(c => c.Id == customerOrderId);
		var update = UpdateDefinition(customerOrderEdit);
		
		return await Collection.FindOneAndUpdateAsync(filter, update, defaultUpdateOptions);
	}

	public async Task<CustomerOrder> EditCustomerOrderStatusAsync(string customerOrderId, DocumentStatus documentStatus)
	{
		var filter = Builders<CustomerOrder>.Filter.Where(c => c.Id == customerOrderId);
		var update = Builders<CustomerOrder>.Update.Set(c => c.DocumentStatus, documentStatus);
		
		return await Collection.FindOneAndUpdateAsync(filter, update, defaultUpdateOptions);
	}

	public async Task DeleteCustomerOrderAsync(string customerOrderId)
	{
		await Collection.DeleteOneAsync(c => c.Id == customerOrderId);
	}

	private UpdateDefinition<CustomerOrder> UpdateDefinition(CustomerOrderEdit customerOrderEdit)
	{
		var updates = new List<UpdateDefinition<CustomerOrder>>();

		if (customerOrderEdit.CustomerId != null)
			updates.Add(Builders<CustomerOrder>.Update.Set(c => c.CustomerId, customerOrderEdit.CustomerId));
		if (customerOrderEdit.EmployeeId != null)
			updates.Add(Builders<CustomerOrder>.Update.Set(c => c.EmployeeId, customerOrderEdit.EmployeeId));
		if (customerOrderEdit.ReservedCarId != null)
			updates.Add(Builders<CustomerOrder>.Update.Set(c => c.ReservedCarId, customerOrderEdit.ReservedCarId));

		return Builders<CustomerOrder>.Update.Combine(updates);
	}
}
