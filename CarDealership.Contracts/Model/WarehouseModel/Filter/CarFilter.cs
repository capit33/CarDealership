using CarDealership.Contracts.Model.Filters;

namespace CarDealership.Contracts.Model.WarehouseModel.Filter;

public class CarFilter : BaseFilter
{
	public string Make { get; set; }
	public string Model { get; set; }
	public string ModelTrim { get; set; }
	public int? Year { get; set; }
}
