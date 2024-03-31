using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts;

public static class ConstantMessages
{
	public const string DeleteError = "can not be delete, it used in other documents.You can change remove status.";
	public const string PageSizeError = "Page size must be greater than 0";
	public const string PageNumberError = "Page number cannot be negative";
	public const string NoFieldsToEdit = "No fields to edit";
	public const string EmployeePositionEmpty = "Position can not be null or empty";
	public const string FirstNameNullOrEmpty = "FirstName can not be null or empty";
	public const string LastNameNullOrEmpty = "LastName can not be null or empty";
	public const string RemoveIsTrue = "IsRemove can not be true";

}
