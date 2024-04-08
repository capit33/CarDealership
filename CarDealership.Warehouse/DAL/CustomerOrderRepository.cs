using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class CustomerOrderRepository : BaseMongoRepository<WarehouseCustomerOrder>, ICustomerOrderRepository
{
	public CustomerOrderRepository(IConfiguration configuration)
		: base(configuration, "warehouseCustomerOrder")
	{
	}

	public Task<WarehouseCustomerOrder> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		return Collection.Find(c => c.Id == customerOrderId).SingleOrDefaultAsync();
	}

	public async Task<WarehouseCustomerOrder> GetCustomerOrderByCarIdAsync(string carId)
	{
		return await Collection.Find(c => c.ReservedCarId == carId).SingleOrDefaultAsync();
	}

	public async Task<WarehouseCustomerOrder> GetCustomerOrderByCarDealershipIdAsync(string carDealershipOrderId)
	{
		return await Collection.Find(c => c.CarDealershipOrderId == carDealershipOrderId).SingleOrDefaultAsync();
	}

	public async Task<List<WarehouseCustomerOrder>> GetCustomerOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		return await Collection.Find(c => c.DocumentStatus == documentStatus)
			.Sort(Builders<WarehouseCustomerOrder>.Sort.Ascending(c => c.CreatedDate))
			.ToListAsync();
	}

	public async Task<WarehouseCustomerOrder> CreateCustomerOrderAsync(WarehouseCustomerOrder customerOrder)
	{
		customerOrder.Id = ObjectId.GenerateNewId().ToString();

		await Collection.InsertOneAsync(customerOrder);
		return await GetCustomerOrderByIdAsync(customerOrder.Id);
	}

	public async Task<WarehouseCustomerOrder> EditCustomerOrderAsync(string customerOrderId, WarehouseCustomerOrderEdit customerOrderEdit)
	{
		var filter = Builders<WarehouseCustomerOrder>.Filter.Where(c => c.Id == customerOrderId);
		var update = UpdateDefinition(customerOrderEdit);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task<WarehouseCustomerOrder> CustomerOrderChangeStatusByIdAsync(string customerOrderId, DocumentStatus documentStatus)
	{
		var filter = Builders<WarehouseCustomerOrder>.Filter.Where(c => c.Id == customerOrderId);
		var update = Builders<WarehouseCustomerOrder>.Update.Set(c => c.DocumentStatus, documentStatus);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task DeleteCustomerOrderByIdAsync(string customerOrderId)
	{
		await Collection.DeleteOneAsync(c => c.Id == customerOrderId);
	}

	private UpdateDefinition<WarehouseCustomerOrder> UpdateDefinition(WarehouseCustomerOrderEdit customerOrderEdit)
	{
		var updates = new List<UpdateDefinition<WarehouseCustomerOrder>>();

		if (customerOrderEdit.CustomerFirstName != null)
			updates.Add(Builders<WarehouseCustomerOrder>.Update.Set(c => c.CustomerFirstName, customerOrderEdit.CustomerFirstName));

		if (customerOrderEdit.CustomerLastName != null)
			updates.Add(Builders<WarehouseCustomerOrder>.Update.Set(c => c.CustomerLastName, customerOrderEdit.CustomerLastName));

		if (customerOrderEdit.ReservedCarId != null)
			updates.Add(Builders<WarehouseCustomerOrder>.Update.Set(c => c.ReservedCarId, customerOrderEdit.ReservedCarId));

		return Builders<WarehouseCustomerOrder>.Update.Combine(updates);
	}
}
