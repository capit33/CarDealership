using CarDealership.Contracts.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehouseCustomerOrder
{
	public string Id { get; set; }
	public string CarDealershipOrderId { get; set; }
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }
	public string CarId { get; set; }
	public DocumentStatus OrderStatus { get; set; }
	public DateTime CreatingDate { get; set; }
}
