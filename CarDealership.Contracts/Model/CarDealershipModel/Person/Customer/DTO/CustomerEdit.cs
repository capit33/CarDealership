using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;

public class CustomerEdit : IObjectValidation
{
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(FirstName)
			&& string.IsNullOrWhiteSpace(LastName))
		{
			errorMessage = ConstantApp.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
