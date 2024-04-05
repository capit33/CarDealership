using CarDealership.Contracts.Model.CarModel;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseSupplierOrderDTO
{
	public string SupplierName { get; set; }
	public Car Car { get; set; }
}
