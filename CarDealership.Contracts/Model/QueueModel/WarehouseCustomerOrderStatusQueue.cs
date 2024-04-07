using CarDealership.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.QueueModel;

public class WarehouseCustomerOrderStatusQueue : BaseQueueMessage
{
	public string CarDealershipOrderId { get; set; }
	public DocumentStatus DocumentStatus { get; set; }
}
