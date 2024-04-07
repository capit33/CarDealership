using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Infrastructure.MessageBroker.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.MessageBroker.Consumers;

public class PurchaseOrderStatusQueueConsumer
	: BaseConsumer<WarehousePurchaseOrderStatusQueue, PurchaseOrderStatusQueueConsumer>
{
	public PurchaseOrderStatusQueueConsumer(ILogger<PurchaseOrderStatusQueueConsumer> logger) 
		: base(logger)
	{
	}

	public override Task HandleMessageAsync(WarehousePurchaseOrderStatusQueue message)
	{
		return base.HandleMessageAsync(message);
	}
}
