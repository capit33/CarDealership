using CarDealership.Contracts.Enum.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Contracts.Model.Car;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class SupplierOrder
{
    public string Id { get; set; }
    public CarModel Car { get; set; }
    public string SupplierName { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatingDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
}
