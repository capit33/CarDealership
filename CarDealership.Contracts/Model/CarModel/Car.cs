﻿using CarDealership.Contracts.Interface;
using CarDealership.Contracts.Model.CarModel.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Contracts.Model.CarModel;

public class Car : ICar
{
	public string Make { get; set; }
	public string Model { get; set; }
	public string ModelTrim { get; set; }
	public int Year { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;

		if (string.IsNullOrWhiteSpace(Make))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(Make));
			return false;
		}

		if (string.IsNullOrWhiteSpace(Model))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(Model));
			return false;
		}

		if (string.IsNullOrWhiteSpace(ModelTrim))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(ModelTrim));
			return false;
		}

		if (Year < ConstantApp.MinProductionYear || Year > DateTime.Today.Year)
		{
			errorMessage = ConstantApp.BadProductionYear;
			return false;
		}

		return true;
	}
}
