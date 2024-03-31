using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.BLL;

public interface IObjectUsageManager
{
	Task<bool> IsEmployeeIdUsedAsync(string employeeId);
}