using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using System;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehouseSupplierOrder
{
    public string Id { get; set; }
    public string SupplierName { get; set; }
    public Car Car { get; set; }
    public DocumentStatus OrderStatus { get; set; }
    public string PurchaseOrderId { get; set; }
    public DateTime CreatingDate { get; set; }
}
