using CarDealership.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Person.Employee;

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
			errorMessage = ConstantMessages.EmployeePositionEmpty;
			return false;
		}

		return true;
	}
}
