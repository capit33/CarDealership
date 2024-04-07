using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class SupplierOrderRepository : BaseMongoRepository<WarehouseSupplierOrder>, ISupplierOrderRepository
{
	public SupplierOrderRepository(IConfiguration configuration) 
		: base(configuration, "warehouseSupplierOrder")
	{
	}

	public Task<WarehouseSupplierOrder> GetSupplierOrderByIdAsync(string supplierOrderId)
	{
		throw new System.NotImplementedException();
	}

	public Task<List<WarehouseSupplierOrder>> GetSupplierOrdersByStatusAsync(DocumentStatus documentStatus)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseSupplierOrder> CreateSupplierOrderAsync(WarehouseSupplierOrder supplierOrder)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseSupplierOrder> EditSupplierOrderAsync(string supplierOrderId, WarehouseSupplierOrderEdit supplierOrderEdit)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseSupplierOrder> EditSupplierOrderProcessingAsync(string supplierOrderId, SupplierOrderConfirm supplierOrderConfirm)
	{
		throw new System.NotImplementedException();
	}

	public Task<WarehouseSupplierOrder> EditSupplierOrderStatusAsync(string supplierOrderId, DocumentStatus status)
	{
		throw new System.NotImplementedException();
	}

	
	public Task DeleteOrderAsync(string supplierOrderId)
	{
		throw new System.NotImplementedException();
	}
}
