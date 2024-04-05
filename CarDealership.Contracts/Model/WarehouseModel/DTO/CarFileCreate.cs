using CarDealership.Contracts.Interface;
using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class CarFileCreate : Car, IObjectValidation
{
	public string Id { get; set; }
	public string VIN { get; set; }

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
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(Make));
			return false;
		}

		if (string.IsNullOrWhiteSpace(ModelTrim))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(Make));
			return false;
		}
		
		if ( Year > DateTime.Today.Year || Year < ConstantApp.MinProductionYear)
		{
			errorMessage = ConstantApp.BadProductionYear;
			return false;
		}

		return true;
	}
}
