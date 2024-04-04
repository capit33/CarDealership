using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehousePurchaseOrder
{
	public string Id { get; set; }
	public string CarDealershipOrderId { get; set; }
	public Car Car { get; set; }
	public DocumentStatus OrderStatus { get; set; }
	public DateTime CreatingDate { get; set; }
}
