using CarDealership.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Person.Customer.DTO;

public class CustomerEdit : IObjectValidation
{
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;
		if (string.IsNullOrWhiteSpace(FirstName)
			|| string.IsNullOrWhiteSpace(LastName))
		{
			errorMessage = ConstantMessages.NoFieldsToEdit;
			return false;
		}
		return true;
	}
}
