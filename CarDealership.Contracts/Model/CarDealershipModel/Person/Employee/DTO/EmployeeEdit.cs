using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;

public class EmployeeEdit : IObjectValidation
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Position { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(FirstName)
			&& string.IsNullOrWhiteSpace(LastName)
			&& string.IsNullOrWhiteSpace(Position))
		{
			errorMessage = ConstantApp.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
