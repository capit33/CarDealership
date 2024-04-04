using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class CustomerOrderEdit
{
	public string CustomerOrderId { get; set; }
	public string ReservedCarId { get; set; }
}
