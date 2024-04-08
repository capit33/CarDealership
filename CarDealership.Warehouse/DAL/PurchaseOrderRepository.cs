using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class PurchaseOrderRepository : BaseMongoRepository<WarehousePurchaseOrder>, IPurchaseOrderRepository
{
	public PurchaseOrderRepository(IConfiguration configuration)
		: base(configuration, "warehousePurchaseOrder")
	{
	}

	public async Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId)
	{
		return await Collection.Find(p => p.Id == purchaseOrderId).SingleOrDefaultAsync();
	}

	public async Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(DocumentStatus documentStatus)
	{
		return await Collection.Find(p => p.DocumentStatus == documentStatus)
			.Sort(Builders<WarehousePurchaseOrder>.Sort.Ascending(p => p.CreatedDate))
			.ToListAsync();
	}

	public async Task<WarehousePurchaseOrder> GetPurchaseOrderBySupplierOrderIdAsync(string supplierOrderId)
	{
		return await Collection.Find(p => p.SupplierOrderId == supplierOrderId).SingleOrDefaultAsync();
	}
	public async Task<WarehousePurchaseOrder> GetPurchaseOrderByCarDealershipIdAsync(string carDealershipOrderId)
	{
		return await Collection.Find(p => p.CarDealershipOrderId == carDealershipOrderId).SingleOrDefaultAsync();
	}

	public async Task<WarehousePurchaseOrder> CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder)
	{
		purchaseOrder.Id = ObjectId.GenerateNewId().ToString();

		await Collection.InsertOneAsync(purchaseOrder);
		return await GetPurchaseOrderByIdAsync(purchaseOrder.Id);
	}

	public async Task<WarehousePurchaseOrder> EditPurchaseOrderStatusAsync(string purchaseOrderId, DocumentStatus documentStatus)
	{
		var filter = Builders<WarehousePurchaseOrder>.Filter.Where(p => p.Id == purchaseOrderId);
		var update = Builders<WarehousePurchaseOrder>.Update.Set(p => p.DocumentStatus, documentStatus);

		return await Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		await Collection.DeleteOneAsync(p => p.Id == purchaseOrderId);
	}
}
