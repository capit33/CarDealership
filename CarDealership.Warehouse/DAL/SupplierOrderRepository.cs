using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.Interface;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class SupplierOrderRepository : BaseMongoRepository<WarehouseSupplierOrder>, ISupplierOrderRepository
{
	public SupplierOrderRepository(IConfiguration configuration)
		: base(configuration, "warehouseSupplierOrder")
	{
	}

	public async Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId)
	{
		return await Collection.Find(s => s.Id == supplierOrderId).SingleOrDefaultAsync();
	}

	public async Task<List<WarehouseSupplierOrder>> GetSupplierOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		return await Collection.Find(s => s.DocumentStatus == documentStatus)
			.Sort(Builders<WarehouseSupplierOrder>.Sort.Ascending(s => s.CreatedDate))
			.ToListAsync();
	}

	public async Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrder supplierOrder)
	{
		supplierOrder.Id = ObjectId.GenerateNewId().ToString();

		await Collection.InsertOneAsync(supplierOrder);
		return await GetSupplierOrderByIdAsync(supplierOrder.Id);
	}

	public async Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, 
		ISupplierOrderEdit supplierOrderEdit, DocumentStatus? documentStatus)
	{
		var filter = Builders<WarehouseSupplierOrder>.Filter.Where(s => s.Id == supplierOrderId);
		var update = UpdateDefinition(supplierOrderEdit, documentStatus);

		if (update == null)
			return await GetSupplierOrderByIdAsync(supplierOrderId);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task DeleteOrderAsync(string supplierOrderId)
	{
		await Collection.DeleteOneAsync(s => s.Id == supplierOrderId);
	}

	private UpdateDefinition<WarehouseSupplierOrder> UpdateDefinition(ISupplierOrderEdit supplierOrderEdit = null, 
		DocumentStatus? documentStatus = null)
	{
		var updates = new List<UpdateDefinition<WarehouseSupplierOrder>>();

		if (documentStatus != null)
			updates.Add(Builders<WarehouseSupplierOrder>.Update.Set(s => s.DocumentStatus, documentStatus));

		if (supplierOrderEdit != null)
		{
			if (supplierOrderEdit.SupplierName != null)
				updates.Add(Builders<WarehouseSupplierOrder>.Update.Set(s => s.SupplierName, supplierOrderEdit.SupplierName));
		}

		if (updates.Any())
			return Builders<WarehouseSupplierOrder>.Update.Combine(updates);

		return null;
	}
}
