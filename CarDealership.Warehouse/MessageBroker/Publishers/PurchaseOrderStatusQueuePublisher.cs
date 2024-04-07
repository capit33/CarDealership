using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Warehouse.Interfaces.MessageBroker;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CarDealership.Warehouse.MessageBroker.Publishers;

public class PurchaseOrderStatusQueuePublisher
    : BasePublisher<WarehousePurchaseOrderStatusQueue, PurchaseOrderStatusQueuePublisher>,
    IPurchaseOrderStatusQueuePublisher
{
    public PurchaseOrderStatusQueuePublisher(IPublishEndpoint publishEndpoint,
        ILogger<PurchaseOrderStatusQueuePublisher> logger)
        : base(publishEndpoint, logger)
    {
    }
}
