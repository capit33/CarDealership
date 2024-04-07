using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker.Interface;

namespace CarDealership.CarDealership.MessageBroker.Interface;

public interface IPurchaseOrderQueuePublisher 
	: IBasePublisher<CarDealershipPurchaseOrderQueue>
{
}