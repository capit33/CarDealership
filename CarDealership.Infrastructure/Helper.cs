using CarDealership.Contracts;
using CarDealership.Contracts.Interface;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure;

public static class Helper
{

	public static bool InputIdValidation(params string[] ids)
	{
		foreach (var id in ids)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentNullException(ConstantApp.IdNullOrEmptyErrorMessage);
		}
		return true;
	}

	public static bool InputDataValidation(IObjectValidation objectValidation)
	{
		if (objectValidation == null)
			throw new ArgumentNullException(ConstantApp.EditObjectNullErrorMessage);

		if (objectValidation.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		return true;
	}
}
