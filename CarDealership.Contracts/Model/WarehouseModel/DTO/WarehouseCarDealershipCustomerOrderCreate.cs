using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseCarDealershipCustomerOrderCreate : WarehouseCustomerOrderCreate
{
	public string CarDealershipOrderId { get; set; }
}
