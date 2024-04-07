using CarDealership.Contracts;
using CarDealership.Contracts.Interface;
using System;
using System.IO;

namespace CarDealership.Infrastructure;

public static class Helper
{

	public static bool InputIdValidation(params string[] ids)
	{
		foreach (var id in ids)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentNullException("Id");
		}
		return true;
	}

	public static bool InputDataValidation(IObjectValidation objectValidation)
	{
		if (objectValidation == null)
			throw new ArgumentNullException(ConstantApp.ObjectNullErrorMessage);

		if (objectValidation.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		return true;
	}
}
