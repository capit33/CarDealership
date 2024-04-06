using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Infrastructure.MessageBroker.Interface;
using CarDealership.Warehouse.MessageBroker.Interface;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CarDealership.Warehouse.MessageBroker.Publisher;

public class CustomerOrderStatusQueuePublisher
	: BasePublisher<WarehouseCustomerOrderStatusQueue, CustomerOrderStatusQueuePublisher>, 
	ICustomerOrderStatusQueuePublisher
{
	public CustomerOrderStatusQueuePublisher(IPublishEndpoint publishEndpoint, 
		ILogger<CustomerOrderStatusQueuePublisher> logger) 
		: base(publishEndpoint, logger)
	{

	}
}
