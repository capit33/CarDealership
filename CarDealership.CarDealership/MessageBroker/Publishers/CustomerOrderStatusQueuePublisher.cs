using CarDealership.CarDealership.MessageBroker.Interface;
using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Infrastructure.MessageBroker.Interface;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership.MessageBroker.Publishers;

public class CustomerOrderStatusQueuePublisher
	: BasePublisher<CarDealershipCustomerOrderStatusQueue, CustomerOrderStatusQueuePublisher>, 
	ICustomerOrderStatusQueuePublisher
{
	public CustomerOrderStatusQueuePublisher(IPublishEndpoint publishEndpoint, 
		ILogger<CustomerOrderStatusQueuePublisher> logger) 
		: base(publishEndpoint, logger)
	{
	}
}
