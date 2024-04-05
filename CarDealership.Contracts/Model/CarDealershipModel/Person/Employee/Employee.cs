namespace CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;

public class Employee : Person
{
	public string Position { get; set; }

	public override bool IsObjectValid(out string errorMessage)
	{
		var baseValidation = base.IsObjectValid(out errorMessage);

		if (!baseValidation)
			return baseValidation;

		if (string.IsNullOrWhiteSpace(Position))
		{
			errorMessage = ConstantApp.EmployeePositionEmpty;
			return false;
		}

		return true;
	}
}
