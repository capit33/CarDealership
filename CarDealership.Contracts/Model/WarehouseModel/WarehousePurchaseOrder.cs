using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehousePurchaseOrder
{
	public string Id { get; set; }
	public string CarDealershipOrderId { get; set; }
	public Car Car { get; set; }
	public string SupplierOrderId { get; set; }
	public DocumentStatus DocumentStatus { get; set; }
	public DateTime CreatedDate { get; set; }
}
