using CarDealership.Contracts.Enum;
using System;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehouseCustomerOrder
{
	public string Id { get; set; }
	public string CarDealershipOrderId { get; set; }
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }
	public string ReservedCarId { get; set; }
	public DocumentStatus DocumentStatus { get; set; }
	public DateTime CreatedDate { get; set; }
}
