using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class CarFileEdit : IObjectValidation
{
	public string Make { get; set; }
	public string Model { get; set; }
	public string ModelTrim { get; set; }
	public int? Year { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;

		if (string.IsNullOrWhiteSpace(Make)
			&& string.IsNullOrWhiteSpace(Model)
			&& string.IsNullOrWhiteSpace(ModelTrim)
			&& Year == null)
		{
			errorMessage = ConstantApp.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
