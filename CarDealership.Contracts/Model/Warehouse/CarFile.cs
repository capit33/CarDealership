using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Car;

namespace CarDealership.Contracts.Model.Warehouse;

public class CarFile : CarModel
{
	public string Id { get; set; }
	public string SupplierOrderId { get; set; }
    public string CustomerOrderId { get; set; }
    public InventoryStatus InventoryStatus { get; set; }
    public string VIN { get; set; }
}
