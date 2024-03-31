using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.BLL;

public interface IObjectUsageManager
{
	Task<bool> IsCunsumerIdUsedAsync(string customerId);
	Task<bool> IsEmployeeIdUsedAsync(string employeeId);
}