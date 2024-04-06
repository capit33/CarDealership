using MassTransit;

namespace CarDealership.Contracts.Model.QueueModel;

[ExcludeFromTopology]
public class BaseQueueMessage
{
    public string CorrelationId { get; set; }
}
