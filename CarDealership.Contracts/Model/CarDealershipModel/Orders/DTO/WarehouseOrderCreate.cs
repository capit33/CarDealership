using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class WarehouseOrderCreate
{
	public Car Car { get; set; }
	public string EmployeeId { get; set; }
}
