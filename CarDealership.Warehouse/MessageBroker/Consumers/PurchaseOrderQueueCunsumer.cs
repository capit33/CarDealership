using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Warehouse.Interfaces.BLL;
using MassTransit.Context;
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

	public override Task HandleMessageAsync(CarDealershipPurchaseOrderQueue message)
	{
		return base.HandleMessageAsync(message);
	}
}
