using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.CarModel.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class CarFile : Car
{
	public string Id { get; set; }
	public string VIN { get; set; }
	[BsonRepresentation(BsonType.String)]
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
