using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.MessageBroker.Consumers;

public class CustomerOrderStatusQueueConsumer
	: BaseConsumer<WarehouseCustomerOrderStatusQueue, CustomerOrderStatusQueueConsumer>
{
	public CustomerOrderStatusQueueConsumer(ILogger<CustomerOrderStatusQueueConsumer> logger) 
		: base(logger)
	{
	}

	public override Task HandleMessageAsync(WarehouseCustomerOrderStatusQueue message)
	{
		return base.HandleMessageAsync(message);
	}
}
