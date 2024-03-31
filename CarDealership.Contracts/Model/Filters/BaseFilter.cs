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
			description = ConstantMessages.PageSizeError;
			return false;
		}

		if (PageNumber < 0)
		{
			description = ConstantMessages.PageNumberError;
			return false;
		}
		return true;
	}
}
