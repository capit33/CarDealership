using CarDealership.Contracts.Model.DTO;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.RestClients;

public interface ICarDealershipRestClient
{
	Task<SearchResult> FindCustomerIdAsync(string customerId);
	Task<SearchResult> FindEmployeeIdAsync(string employeeId);
}