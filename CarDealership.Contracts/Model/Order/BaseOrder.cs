using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Order;

public class BaseOrder
{
    public string Id { get; set; }
    public string EmployeeId { get; set; }
    public CarModel Car { get; set; }
    public DocumentStatus OrderStatus { get; set; }
    public DateTime CreatingDate { get; set; }
}
