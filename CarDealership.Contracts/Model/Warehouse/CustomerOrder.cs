using CarDealership.Contracts.Enum.Warehouse;
using CarDealership.Contracts.Model.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class CustomerOrder
{
    public string Id { get; set; }
    public CarModel Car { get; set; }
    public string CustomerId { get; set; }
    public string EmployeeId { get; set; }
    public string CarFileId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatingDate { get; set; }
}
