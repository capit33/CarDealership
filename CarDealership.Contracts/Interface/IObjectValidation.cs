namespace CarDealership.Contracts.Interface;

public interface IObjectValidation
{
	public bool IsObjectValid(out string errorMessage);
}
