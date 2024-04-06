using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderEdit
{
	public string CustomerId { get; set; }
	public string ReservedCarId { get; set; }
}
