using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel.Interface;
using RabbitMQ.Client;

namespace CarDealership.Contracts.Model.CarModel;

public class CarInfo : Car
{
	public string CarId { get; set; }
	public InventoryStatus InventoryStatus { get; set; }

	public CarInfo()
	{
	}

	public CarInfo(string carId, InventoryStatus inventoryStatus , ICar car)
	{
		CarId = carId;
		InventoryStatus = InventoryStatus;
		Make = car.Make;
		Model = car.Model;
		ModelTrim = car.ModelTrim;
		Year = car.Year;
		InventoryStatus = inventoryStatus;
	}
}
