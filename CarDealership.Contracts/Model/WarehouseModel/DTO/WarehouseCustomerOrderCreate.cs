using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseCustomerOrderCreate : IObjectValidation
{
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }
	public string ReservedCarId { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;

		if (string.IsNullOrWhiteSpace(CustomerFirstName))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(CustomerFirstName));
			return false;
		}

		if (string.IsNullOrWhiteSpace(CustomerLastName))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(CustomerLastName));
			return false;
		}
		if (string.IsNullOrWhiteSpace(ReservedCarId))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(ReservedCarId));
			return false;
		}

		return true;
	}
}
