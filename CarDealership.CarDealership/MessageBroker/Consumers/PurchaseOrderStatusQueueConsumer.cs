using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.MessageBroker.Consumers;

public class PurchaseOrderStatusQueueConsumer
	: BaseConsumer<WarehousePurchaseOrderStatusQueue, PurchaseOrderStatusQueueConsumer>
{
	private IWarehouseOrderManager WarehouseOrderManager { get; }

	public PurchaseOrderStatusQueueConsumer(ILogger<PurchaseOrderStatusQueueConsumer> logger, 
		IWarehouseOrderManager warehouseOrderManager) 
		: base(logger)
	{
		WarehouseOrderManager = warehouseOrderManager;
	}

	public override async Task HandleMessageAsync(WarehousePurchaseOrderStatusQueue message)
	{
		await WarehouseOrderManager.WarehouseNotifyOrderStatusChangedAsync(message.CarDealershipOrderId, message.DocumentStatus);
	}
}
