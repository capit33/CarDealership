using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using CarDealership.Warehouse.Interfaces.MessageBroker;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class ChangeOrderStatusManager : IChangeOrderStatusManager
{
	private IPurchaseOrderRepository PurchaseOrderRepository { get; }
	private ICustomerOrderRepository CustomerOrderRepository { get; }
	private IPurchaseOrderStatusQueuePublisher PurchaseOrderStatusQueuePublisher { get;}
	private ICustomerOrderStatusQueuePublisher CustomerOrderStatusQueuePublisher { get; }

	public ChangeOrderStatusManager(IPurchaseOrderRepository purchaseOrderRepository,
		ICustomerOrderRepository customerOrderRepository,
		IPurchaseOrderStatusQueuePublisher purchaseOrderStatusQueuePublisher,
		ICustomerOrderStatusQueuePublisher customerOrderStatusQueuePublisher)
	{
		PurchaseOrderRepository = purchaseOrderRepository;
		CustomerOrderRepository = customerOrderRepository;
		PurchaseOrderStatusQueuePublisher = purchaseOrderStatusQueuePublisher;
		CustomerOrderStatusQueuePublisher = customerOrderStatusQueuePublisher;
	}

	public async Task CarDeleteAsync(string carId)
	{
		var customerOrder = await CustomerOrderRepository.GetCustomerOrderByCarIdAsync(carId);

		if (customerOrder == null) 
			return;

		if (customerOrder.CarDealershipOrderId == null)
			return;

		await CustomerOrderRepository.CustomerOrderChangeStatusByIdAsync(customerOrder.Id, DocumentStatus.Canceled);

		await CustomerOrderStatusQueuePublisher.SendMessage(new()
		{
			CarDealershipOrderId = customerOrder.CarDealershipOrderId,
			DocumentStatus = DocumentStatus.Canceled
		});
	}

	public async Task CustomerOrderStatusChangeAsync(WarehouseCustomerOrder customerOrder, DocumentStatus processing)
	{
		if (customerOrder == null)
			throw new ArgumentNullException(nameof(customerOrder));

		if (customerOrder.CarDealershipOrderId == null)
			return;

		await CustomerOrderStatusQueuePublisher.SendMessage(new()
		{
			CarDealershipOrderId = customerOrder.CarDealershipOrderId,
			DocumentStatus = processing
		});
	}

	public async Task SupplierOrderStatusChanged(string supplierOrderId, DocumentStatus processing)
	{
		Helper.InputIdValidation(supplierOrderId);

		var purchaseOrder = await PurchaseOrderRepository.GetPurchaseSupplierIdAsync(supplierOrderId);

		if (purchaseOrder == null || purchaseOrder.CarDealershipOrderId == null)
			return;

		await PurchaseOrderRepository.EditPurchaseOrderStatusAsync(purchaseOrder.Id, processing);

		await PurchaseOrderStatusQueuePublisher.SendMessage(new()
		{
			CarDealershipOrderId = purchaseOrder.CarDealershipOrderId,
			DocumentStatus = processing
		});
	}
}
