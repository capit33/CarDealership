using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker.Interface;

namespace CarDealership.Warehouse.MessageBroker.Interface;

public interface IPurchaseOrderStatusQueuePublisher : IBasePublisher<WarehousePurchaseOrderStatusQueue>
{
}