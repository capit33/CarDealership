using CarDealership.Contracts.Interface;
using System;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderCreate : IObjectValidation
{
	public string CustomerId { get; set; }
	public string EmployeeId { get; set; }
	public string ReservedCarId { get; set; }

	public bool IsObjectValid(out string errorMessage)
	{
		errorMessage = string.Empty;

		if (string.IsNullOrWhiteSpace(CustomerId))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(CustomerId));
			return false;
		}

		if (string.IsNullOrWhiteSpace(EmployeeId))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(EmployeeId));
			return false;
		}

		if (string.IsNullOrWhiteSpace(ReservedCarId))
		{
			errorMessage = ConstantApp.GetMessageNullOrEmpty(nameof(ReservedCarId));
			return false;
		}

		return true;
	}
}
