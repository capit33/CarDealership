using CarDealership.PersonsAdministration.Interfaces.BLL;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.BLL;

public class ObjectUsageManager : IObjectUsageManager
{
	public Task<bool> IsCustomerIdUsedAsync(string customerId)
	{
		throw new System.NotImplementedException();
	}

	public async Task<bool> IsEmployeeIdUsedAsync(string employeeId)
	{
		// TODO: check the use object in other objects 
		await Task.CompletedTask;
		return false;
	}
}
