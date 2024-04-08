using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.RestClients
{
	public interface IPersonsAdministrationRestClient
	{
		Task<Customer> GetCustomerByIdAsync(string customerId);
		Task<Employee> GetEmployeeByIdAsync(string employeeId);
	}
}