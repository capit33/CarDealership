using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders;

public class WarehouseOrder
{
	public string Id { get; set; }
	public Car Car { get; set; }
	public string EmployeeId { get; set; }
	public DocumentStatus DocumentStatus { get; set; }
	public DateTime CreatedDate { get; set; }
}
