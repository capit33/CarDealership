using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Warehouse.Interfaces.MessageBroker;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CarDealership.Warehouse.MessageBroker.Publishers;

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
