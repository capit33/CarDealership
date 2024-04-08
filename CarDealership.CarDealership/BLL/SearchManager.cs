using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.DTO;
using CarDealership.Infrastructure;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.BLL;

public class SearchManager : ISearchManager
{
	private ICustomerOrderRepository CustomerOrderRepository { get; }
	private IWarehouseOrderRepository WarehouseOrderRepository { get; }

	public SearchManager(ICustomerOrderRepository customerOrderRepository, IWarehouseOrderRepository warehouseOrderRepository)
	{
		CustomerOrderRepository = customerOrderRepository;
		WarehouseOrderRepository = warehouseOrderRepository;
	}

	public async Task<SearchResult> FindCustomerIdAsync(string customerOrderId)
	{
		Helper.InputIdValidation(customerOrderId);
		var customerOrder = await CustomerOrderRepository.GetFirstEntryCustomerIdAsync(customerOrderId);
		if (customerOrder != null)
			return new SearchResult() { Result = SearchResultEnum.Found };

		return new SearchResult() { Result = SearchResultEnum.NotFound };
	}

	public async Task<SearchResult> FindEmployeeIdAsync(string employeeOrderId)
	{
		Helper.InputIdValidation(employeeOrderId);

		var customerOrder = await CustomerOrderRepository.GetFirstEntryEmployeeIdAsync(employeeOrderId);
		if (customerOrder != null)
			return new SearchResult() { Result = SearchResultEnum.Found };

		var warehouseOrder = await WarehouseOrderRepository.GetFirstEntryEmployeeIdAsync(employeeOrderId);
		if (warehouseOrder != null)
			return new SearchResult() { Result = SearchResultEnum.Found };

		return new SearchResult() { Result = SearchResultEnum.NotFound };
	}
}
