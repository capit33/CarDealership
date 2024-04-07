using CarDealership.Contracts.Enum;

namespace CarDealership.Contracts.Model.QueueModel;

public class CarDealershipCustomerOrderStatusQueue : BaseQueueMessage
{
	public string CarDealershipOrderId { get; set; }
	public DocumentStatus OrderStatus { get; set; }
}
