using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Warehouse;
using System;

namespace CarDealership.Contracts.Model.Invoice;

public class BaseInvoice
{
    public string Id { get; set; }
    public string OrderId { get; set; }
    public CarFile CarFile { get; set; }
    public DocumentStatus DocumentStatus { get; set; }
    public DateTime CreatingDate { get; set; }
}
