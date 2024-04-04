using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.WarehouseModel.Filter;

public class CarFilter : BaseFilter
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string ModelTrim { get; set; }
    public int? Year { get; set; }
    public InventoryStatus? InventoryStatus { get; set; }
}
