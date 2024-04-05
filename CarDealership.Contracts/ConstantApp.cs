using DnsClient.Protocol;

namespace CarDealership.Contracts;

public static class ConstantApp
{
	public const string DeleteError = "can not be delete, it used in other documents.You can change remove status.";
	public const string PageSizeError = "Page size must be greater than 0";
	public const string PageNumberError = "Page number cannot be negative";
	public const string NoFieldsToEdit = "No fields to edit";
	public const string RemoveIsTrue = "IsRemove can not be true";
	
	public const int MinProductionYear = 1900;
	public static readonly string BadProductionYear = $"The year of production cannot be less than {1900} and greater than the current year";

	public const string SuffixNullOrEmptyErrorMessage = "can not be null or empty";

	public static string GetMessageNullOrEmpty(string prefix)
	{
		return $"{prefix} {SuffixNullOrEmptyErrorMessage}.";
	}


}
