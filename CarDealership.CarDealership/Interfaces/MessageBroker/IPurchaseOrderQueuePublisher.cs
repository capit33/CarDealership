using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker.Interface;

namespace CarDealership.CarDealership.Interfaces.MessageBroker;

public interface IPurchaseOrderQueuePublisher
    : IBasePublisher<CarDealershipPurchaseOrderQueue>
{
}