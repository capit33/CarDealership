using System.Collections.Generic;

namespace CarDealership.Contracts.Model.Filters;

public class PageItems<T> : BaseFilter
{
	public List<T> Items { get; set; }

	public PageItems()
	{

	}

	public PageItems(BaseFilter baseFilter) : base(baseFilter)
	{
		Items = new List<T>();
	}
}
