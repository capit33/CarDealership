using CarDealership.Contracts.Interface;

namespace CarDealership.Contracts.Model.Person;

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
			errorMessage = ConstantMessages.FirstNameNullOrEmpty;
			return false;
		}

		if (string.IsNullOrWhiteSpace(LastName))
		{
			errorMessage = ConstantMessages.LastNameNullOrEmpty;
			return false;
		}

		if (IsRemove)
		{
			errorMessage = ConstantMessages.RemoveIsTrue;
			return false;
		}

		return true;
	}
}
