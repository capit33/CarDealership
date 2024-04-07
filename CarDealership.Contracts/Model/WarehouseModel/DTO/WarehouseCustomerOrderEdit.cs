using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseCustomerOrderEdit : IObjectValidation
{
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }
	public string ReservedCarId { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(CustomerFirstName)
			&& string.IsNullOrWhiteSpace(CustomerLastName)
			&& string.IsNullOrWhiteSpace(ReservedCarId))
		{
			errorMessage = ConstantApp.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
