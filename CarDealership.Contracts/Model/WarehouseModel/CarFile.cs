using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.CarModel.Interface;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class CarFile : Car
{
	public string Id { get; set; }
	public string VIN { get; set; }
	public InventoryStatus InventoryStatus { get; set; }

	public CarFile()
	{

	}

	public CarFile(ICar car, InventoryStatus inventoryStatus)
	{
		Make = car.Make;
		Model = car.Model;
		ModelTrim = car.ModelTrim;
		Year = car.Year;
		InventoryStatus = inventoryStatus;
	}
}
