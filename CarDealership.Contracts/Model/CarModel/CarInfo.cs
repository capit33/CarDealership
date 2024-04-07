namespace CarDealership.Contracts.Model.CarModel;

public class CarInfo : Car
{
	public string CarId { get; set; }

	public CarInfo()
	{
	}

	public CarInfo(string carId, Car car)
	{
		CarId = carId;
		Make = car.Make;
		Model = car.Model;
		ModelTrim = car.ModelTrim;
		Year = car.Year;
	}
}
