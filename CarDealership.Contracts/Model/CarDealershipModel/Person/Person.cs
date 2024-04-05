using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.CarDealershipModel.Person;

public class Person : IObjectValidation
{
	public string Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public bool IsRemove { get; set; }

	public virtual bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;

		if (string.IsNullOrWhiteSpace(FirstName))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(FirstName));
			return false;
		}

		if (string.IsNullOrWhiteSpace(LastName))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(LastName));
			return false;
		}

		if (IsRemove)
		{
			errorMessage = ConstantApp.RemoveIsTrue;
			return false;
		}

		return true;
	}
}
