using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders;

public class WarehouseOrder
{
    public string Id { get; set; }
    public Car Car { get; set; }
	public string EmployeeId { get; set; }
	public DocumentStatus OrderStatus { get; set; }
    public DateTime CreatingDate { get; set; }
}
