using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseSupplierOrderEdit
{
	public string SupplierName { get; set; }
	public CarFileEdit CarEditing { get; set; }	
}
