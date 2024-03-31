using CarDealership.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			errorMessage = "FirstName can not be null or empty";
			return false;
		}

		if (string.IsNullOrWhiteSpace(LastName))
		{
			errorMessage = "LastName can not be null or empty";
			return false;
		}

		return true;
	}
}
