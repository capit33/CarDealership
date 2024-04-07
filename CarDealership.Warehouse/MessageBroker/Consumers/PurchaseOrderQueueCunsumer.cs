using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.MessageBroker.Consumers;

public class PurchaseOrderQueueConsumer 
	: BaseConsumer<CarDealershipPurchaseOrderQueue, PurchaseOrderQueueConsumer>
{
	private IPurchaseOrderManager PurchaseOrderManager { get; }
	
	public PurchaseOrderQueueConsumer(ILogger<PurchaseOrderQueueConsumer> logger, 
		IPurchaseOrderManager purchaseOrderManager) 
		: base(logger)
	{
		PurchaseOrderManager = purchaseOrderManager;
	}

	public override async Task HandleMessageAsync(CarDealershipPurchaseOrderQueue message)
	{
		var purchaseOrder = new WarehousePurchaseOrder()
		{
			CarDealershipOrderId = message.OrderId,
			Car = message.Car
		};

		await PurchaseOrderManager.CreatePurchaseOrderAsync(purchaseOrder);
	}
}
