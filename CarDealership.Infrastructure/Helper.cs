using CarDealership.Contracts;
using CarDealership.Contracts.Interface;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
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

	public static void NullValidation(object obj, string value)
	{
		if (obj == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage("Object", value));
	}
}
