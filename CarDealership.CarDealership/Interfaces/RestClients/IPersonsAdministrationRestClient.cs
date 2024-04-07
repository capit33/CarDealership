using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.RestClients
{
	public interface IPersonsAdministrationRestClient
	{
		Task<Employee> GetEmployeeByIdAsync(string employeeId);
	}
}