using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderEdit : IObjectValidation
{
	public string CustomerId { get; set; }
	public string EmployeeId { get; set; }
	public string ReservedCarId { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(CustomerId)
			&& string.IsNullOrWhiteSpace(EmployeeId)
			&& string.IsNullOrWhiteSpace(ReservedCarId))
		{
			errorMessage = ConstantApp.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
