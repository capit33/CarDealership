using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.MessageBroker.Consumers;

public class CustomerOrderStatusQueueConsumer
	: BaseConsumer<WarehouseCustomerOrderStatusQueue, CustomerOrderStatusQueueConsumer>
{
	private ICustomerOrderManager CustomerOrderManager { get; }

	public CustomerOrderStatusQueueConsumer(ILogger<CustomerOrderStatusQueueConsumer> logger,
		ICustomerOrderManager customerOrderManager) 
		: base(logger)
	{
		CustomerOrderManager = customerOrderManager;
	}

	public override async Task HandleMessageAsync(WarehouseCustomerOrderStatusQueue message)
	{
		await CustomerOrderManager.WarehouseNotifyOrderStatusChangedAsync(message.CarDealershipOrderId, message.DocumentStatus);
	}
}
