using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.QueueModel;

public class CarDealershipPurchaseOrderQueue : BaseQueueMessage
{
	public string OrderId { get; set; }
	public Car Car { get; set; }
}
