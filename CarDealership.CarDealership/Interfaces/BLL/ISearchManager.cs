using CarDealership.Contracts.Model.DTO;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL;

public interface ISearchManager
{
	Task<SearchResult> FindCustomerIdAsync(string customerId);
	Task<SearchResult> FindEmployeeIdAsync(string employeeId);
}