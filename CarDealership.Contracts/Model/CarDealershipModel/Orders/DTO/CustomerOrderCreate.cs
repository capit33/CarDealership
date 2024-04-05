using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderCreate
{
	public string CustomerId { get; set; }
	public Car Car { get; set; }
	public string EmployeeId { get; set; }
}
