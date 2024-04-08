using CarDealership.CarDealership.Interfaces.MessageBroker;
using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership.MessageBroker.Publishers;

public class PurchaseOrderQueuePublisher
	: BasePublisher<CarDealershipPurchaseOrderQueue, PurchaseOrderQueuePublisher>,
	IPurchaseOrderQueuePublisher
{
	public PurchaseOrderQueuePublisher(IPublishEndpoint publishEndpoint,
		ILogger<PurchaseOrderQueuePublisher> logger)
		: base(publishEndpoint, logger)
	{
	}
}
