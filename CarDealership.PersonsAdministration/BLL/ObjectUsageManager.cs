using CarDealership.PersonsAdministration.Interfaces.BLL;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.BLL;

public class ObjectUsageManager : IObjectUsageManager
{
	public async Task<bool> IsEmployeeIdUsedAsync(string employeeId)
	{
		// TODO: check the use object in other objects 
		await Task.CompletedTask;
		return false;
	}
}
