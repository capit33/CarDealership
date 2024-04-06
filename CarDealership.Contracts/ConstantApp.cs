using System.Runtime.Serialization;

namespace CarDealership.Contracts;

public static class ConstantApp
{
	public const string DeleteError = "can not be delete, it used in other documents.You can change remove status.";
	public const string PageSizeError = "Page size must be greater than 0";
	public const string PageNumberError = "Page number cannot be negative";
	public const string NoFieldsToEdit = "No fields to edit";
	public const string RemoveIsTrue = "IsRemove can not be true";
	public const string CarNotFindError = "The car is not find.";
	public const string CarNotAvailableError = "The car is not available.";
	public const string CarStatusNotValidError = "The car status is not valid.";
	public const string CarNotReservationError = "The car is not reservation.";
	public const string DocumentStatusNotValidError = "The document status is not valid.";
	public const string SupplierOrderNotFindError = "The Supplier Order is not find.";

	public const int MinProductionYear = 1900;
	public static readonly string BadProductionYear = $"The year of production cannot be less than {1900} and greater than the current year";
	public const string SuffixNullOrEmptyErrorMessage = "can not be null or empty";
	

	public static string GetMessageNullOrEmpty(string prefix)
	{
		return $"{prefix} {SuffixNullOrEmptyErrorMessage}.";
	}

	public static string GetErrorMessageDeleteNotPossible(string propertyName, string propertyValue)
	{
		return $"Deletion is impossible! In properties - {propertyName} is set \"{propertyValue}\".";
	}

	public static string GetErrorMessageEditNotPossible(string propertyName, string propertyValue)
	{
		return $"Edition is impossible! In properties - {propertyName} is set \"{propertyValue}\".";
	}
}
