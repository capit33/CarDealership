using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

public class CustomerOrderEdit
{
	public string CustomerId { get; set; }
	public Car Car { get; set; }
}
