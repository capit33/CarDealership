using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderCreate
{
	public string CustomerId { get; set; }
	public Car Car { get; set; }
	public string EmployeeId { get; set; }
}
