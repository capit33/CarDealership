using CarDealership.Contracts.Enum.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model;

public class WarehouseInvoice
{
    public string Id { get; set; }
    public string VendorName { get; set; }
    public DateTime CreatingDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public List<Car> Items { get; set; }
}
