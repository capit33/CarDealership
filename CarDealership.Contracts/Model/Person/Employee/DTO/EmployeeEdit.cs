using CarDealership.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Person.Employee.DTO;

public class EmployeeEdit : IObjectValidation
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Position { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(FirstName) 
			|| string.IsNullOrWhiteSpace(LastName)
			|| string.IsNullOrWhiteSpace(Position))
		{
			errorMessage = ConstantMessages.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
