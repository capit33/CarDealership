using CarDealership.Contracts.Model.WarehouseModel.Interface;

namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseSupplierOrderEdit : ISupplierOrderEdit
{
	public string SupplierName { get; set; }
	public CarFileEdit CarEditing { get; set; }
}
