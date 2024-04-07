namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderCreate
{
	public string CustomerId { get; set; }
	public string EmployeeId { get; set; }
	public string ReservedCarId { get; set; }
}
