using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Orders;
using CarDealership.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.DAL;

public class WarehouseOrderRepository
	: BaseMongoRepository<WarehouseOrder>, IWarehouseOrderRepository
{
	public WarehouseOrderRepository(IConfiguration configuration)
		: base(configuration, "warehouseOrder")
	{
	}

	public async Task<WarehouseOrder> GetWarehouseOrderByIdAsync(string warehouseOrderId)
	{
		return await Collection.Find(w => w.Id == warehouseOrderId).SingleOrDefaultAsync();
	}

	public async Task<List<WarehouseOrder>> GetWarehouseOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		return await Collection.Find(c => c.DocumentStatus == documentStatus)
			.Sort(Builders<WarehouseOrder>.Sort.Ascending(w => w.CreatedDate))
			.ToListAsync();
	}

	public async Task<WarehouseOrder> GetFirstEntryEmployeeIdAsync(string employeeId)
	{
		return await Collection.Find(c => c.EmployeeId == employeeId).FirstOrDefaultAsync();

	}

	public async Task<WarehouseOrder> CreateWarehouseOrderAsync(WarehouseOrder warehouseOrder)
	{
		warehouseOrder.Id = ObjectId.GenerateNewId().ToString();

		await Collection.InsertOneAsync(warehouseOrder);
		return await GetWarehouseOrderByIdAsync(warehouseOrder.Id);
	}

	public async Task<WarehouseOrder> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId)
	{
		var filter = Builders<WarehouseOrder>.Filter.Where(c => c.Id == warehouseOrderId);
		var update = Builders<WarehouseOrder>.Update.Set(c => c.EmployeeId, employeeId);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task<WarehouseOrder> EditWarehouseOrderStatusAsync(string warehouseOrderId, DocumentStatus documentStatus)
	{
		var filter = Builders<WarehouseOrder>.Filter.Where(c => c.Id == warehouseOrderId);
		var update = Builders<WarehouseOrder>.Update.Set(c => c.DocumentStatus, documentStatus);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task DeleteWarehouseOrderAsync(string warehouseOrderId)
	{
		await Collection.DeleteOneAsync(w => w.Id == warehouseOrderId);
	}
}
