using CarDealership.Contracts.Model.Filters;

namespace CarDealership.Contracts.Model.CarDealershipModel.Filter;

public class CustomerFilter : BaseFilter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsRemove { get; set; }
}
