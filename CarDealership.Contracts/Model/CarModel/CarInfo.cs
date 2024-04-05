namespace CarDealership.Contracts.Model.CarModel;

public class CarInfo : Car
{
	public string Id { get; set; }

	public CarInfo()
	{
	}

	public CarInfo(string id, Car car)
	{
		Id = id;
		Make = car.Make;
		Model = car.Model;
		ModelTrim = car.ModelTrim;
		Year = car.Year;
	}
}
