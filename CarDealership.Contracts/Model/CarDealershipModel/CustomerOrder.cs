using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;

namespace CarDealership.Contracts.Model.CarDealershipModel;

public class CustomerOrder
{
    public string Id { get; set; }
    public Car Car { get; set; }
    public string CustomerId { get; set; }
    public string EmployeeId { get; set; }
    public DocumentStatus OrderStatus { get; set; }
	public DateTime CreatingDate { get; set; }
}
