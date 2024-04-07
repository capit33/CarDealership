using CarDealership.Contracts.Enum;

namespace CarDealership.Contracts.Model.QueueModel;

public class WarehousePurchaseOrderStatusQueue : BaseQueueMessage
{
	public string CarDealershipOrderId { get; set; }
	public DocumentStatus DocumentStatus { get; set; }
}
