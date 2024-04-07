using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.QueueModel;

public class CarDealershipPurchaseOrderQueue : BaseQueueMessage
{
	public string OrderId { get; set; }
	public Car Car { get; set; }
}
