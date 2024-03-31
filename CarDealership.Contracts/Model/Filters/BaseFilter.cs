using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Contracts.Model.Filters;

public class BaseFilter 
{
	public int PageSize { get; set; }
	public int PageNumber { get; set; }
	public int PageCount { get; set; }

	public BaseFilter() 
	{ 
	
	}

	public BaseFilter(BaseFilter baseFilter)
	{
		PageSize = baseFilter.PageSize;
		PageNumber = baseFilter.PageNumber;
		PageCount = baseFilter.PageCount;
	}

	public bool IsPaginationValid(out string description)
	{
		description = string.Empty;
		if (PageSize <= 0)
		{
			description = "Page size must be greater than 0";
			return false;
		}

		if (PageNumber < 0)
		{
			description = "Page number cannot be negative";
			return false;
		}
		return true;
	}
}
