using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.CarModel.Interface;

public interface ICar : IObjectValidation
{
	public string Make { get; set; }
	public string Model { get; set; }
	public string ModelTrim { get; set; }
	public int Year { get; set; }
}