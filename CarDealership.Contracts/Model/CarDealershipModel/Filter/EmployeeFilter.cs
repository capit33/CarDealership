namespace CarDealership.Contracts.Model.Filters;

public class EmployeeFilter : BaseFilter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public bool? IsRemove { get; set; }
}
