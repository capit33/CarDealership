using CarDealership.Contracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Filters;

public class EmployeeFilter : BaseFilter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public bool? IsRemove { get; set; }
}
