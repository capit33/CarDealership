using CarDealership.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class CarFileEdit
{
	public string Make { get; set; }
	public string Model { get; set; }
	public string ModelTrim { get; set; }
	public int Year { get; set; }
	public string VIN { get; set; }
}
