using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker.Interface;

namespace CarDealership.Warehouse.Interfaces.MessageBroker;

public interface ICustomerOrderStatusQueuePublisher : IBasePublisher<WarehouseCustomerOrderStatusQueue>
{

}