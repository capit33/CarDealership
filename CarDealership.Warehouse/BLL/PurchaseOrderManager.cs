using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class PurchaseOrderManager : IPurchaseOrderManager
{
	private IPurchaseOrderRepository PurchaseOrderRepository { get; }
	private ISupplierOrderManager SupplierOrderManager { get; }

	public PurchaseOrderManager(IPurchaseOrderRepository purchaseOrderRepository, 
		ISupplierOrderManager supplierOrderManager)
	{
		PurchaseOrderRepository = purchaseOrderRepository;
		SupplierOrderManager = supplierOrderManager;
	}

	public async Task<WarehousePurchaseOrder> GetPurchaseOrderByIdAsync(string purchaseOrderId)
	{
		if (string.IsNullOrWhiteSpace(purchaseOrderId))
			throw new ArgumentNullException(nameof(purchaseOrderId));

		return await PurchaseOrderRepository.GetPurchaseOrderByIdAsync(purchaseOrderId);
	}

	public async Task<List<WarehousePurchaseOrder>> GetPurchaseOrderByStatusAsync(string status)
	{
		DocumentStatus documentStatus;
		if (!Enum.TryParse(status, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await PurchaseOrderRepository.GetPurchaseOrderByStutusAsync(documentStatus);
	}

	public async Task DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		if (string.IsNullOrWhiteSpace(purchaseOrderId))
			throw new ArgumentNullException(nameof(purchaseOrderId));

		var purchaseOrder = await GetPurchaseOrderByIdAsync(purchaseOrderId);

		if (purchaseOrder != null)
			return;

		if (purchaseOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageDeleteNotPossible(nameof(purchaseOrder.DocumentStatus), purchaseOrder.DocumentStatus.ToString()));

		await PurchaseOrderRepository.DeletePurchaseOrderAsync(purchaseOrderId);
	}
}
