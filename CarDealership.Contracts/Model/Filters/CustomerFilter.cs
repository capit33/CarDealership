namespace CarDealership.Contracts.Model.Filters;

public class CustomerFilter : BaseFilter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsRemove { get; set; }
}
