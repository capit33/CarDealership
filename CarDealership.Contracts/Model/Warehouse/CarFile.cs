using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Warehouse;

public class CarFile : CarModel
{
    public string Id { get; set; }
    public string SupplierInvoiceId { get; set; }
    public string CustomerOrderId { get; set; }
    public string CustomerInvoiceId { get; set; }
    public InventoryStatus InventoryStatus { get; set; }
    public string VIN { get; set; }
}
