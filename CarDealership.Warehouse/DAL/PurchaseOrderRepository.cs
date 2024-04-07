using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class PurchaseOrderRepository : BaseMongoRepository<WarehousePurchaseOrder>, IPurchaseOrderRepository
{
	public PurchaseOrderRepository(IConfiguration configuration) 
		: base(configuration, "warehousePurchaseOrder")
	{
	}

	public Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(DocumentStatus documentStatus)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehousePurchaseOrder> GetPurchaseSupplierIdAsync(string supplierOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehousePurchaseOrder> GetPurchaseOrderByCarDealershipIdAsync(string purchaseOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder)
	{
		throw new System.NotImplementedException();
	}

	public Task DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		throw new System.NotImplementedException();
	}
}
