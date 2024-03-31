using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Car;
using System;

namespace CarDealership.Contracts.Model.Order;

public class CustomerOrder
{
	public string Id { get; set; }
	public CarModel Car { get; set; }
	public DocumentStatus OrderStatus { get; set; }
	public DateTime CreatingDate { get; set; }
	public string CustomerId { get; set; }
}
