using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure;
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
		if (!Enum.TryParse(status, true, out documentStatus))
			throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);

		return await PurchaseOrderRepository.GetPurchaseOrderByStatusAsync(documentStatus);
	}

	public async Task CreatePurchaseOrderAsync(WarehousePurchaseOrder purchaseOrder)
	{
		if (purchaseOrder == null)
			throw new ArgumentNullException(nameof(purchaseOrder));

		if (string.IsNullOrEmpty(purchaseOrder.CarDealershipOrderId))
			throw new ArgumentNullException(nameof(purchaseOrder.CarDealershipOrderId));

		if (!purchaseOrder.Car.IsObjectValid(out var errorMessage))
			throw new InvalidDataException(errorMessage);

		var supplierOrder = await SupplierOrderManager.CreateSupplierOrderFromPurchaseOrderAsync(purchaseOrder);

		if (supplierOrder == null)
			throw new Exception("Supplier order is not created.");

		purchaseOrder.SupplierOrderId = supplierOrder.Id;
		purchaseOrder.DocumentStatus = DocumentStatus.Created;
		purchaseOrder.CreatedDate = DateTime.UtcNow;

		await PurchaseOrderRepository.CreatePurchaseOrderAsync(purchaseOrder);
	}

	public async Task CanceledPurchaseOrderCarDealershipAsync(string carDealershipOrderId)
	{
		Helper.InputIdValidation(carDealershipOrderId);

		var purchaseOrder = await PurchaseOrderRepository.GetPurchaseOrderByCarDealershipIdAsync(carDealershipOrderId);

		if (purchaseOrder == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(purchaseOrder), carDealershipOrderId));

		if (purchaseOrder.DocumentStatus != DocumentStatus.Created)
			throw new InvalidOperationException(ConstantApp.DocumentStatusNotValidError);

		await PurchaseOrderRepository.EditPurchaseOrderStatusAsync(purchaseOrder.Id, DocumentStatus.Canceled);
	}

	public async Task DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		if (string.IsNullOrWhiteSpace(purchaseOrderId))
			throw new ArgumentNullException(nameof(purchaseOrderId));

		var purchaseOrder = await GetPurchaseOrderByIdAsync(purchaseOrderId);

		if (purchaseOrder == null)
			return;

		if (purchaseOrder.DocumentStatus != DocumentStatus.Canceled)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageDeleteNotPossible(nameof(purchaseOrder.DocumentStatus), purchaseOrder.DocumentStatus.ToString()));

		await PurchaseOrderRepository.DeletePurchaseOrderAsync(purchaseOrderId);
	}
}
