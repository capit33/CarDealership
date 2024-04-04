using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class CarFile : Car
{
    public string Id { get; set; }
    public string SupplierOrderId { get; set; }
    public InventoryStatus InventoryStatus { get; set; }
    public string VIN { get; set; }
}
