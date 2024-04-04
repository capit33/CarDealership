using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;
using CarDealership.Contracts.Model.Filters;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.BLL;

public interface IEmployeeManager
{
	Task<Employee> GetEmployeeByIdAsync(string employeeId);
	Task<PageItems<Employee>> GetEmployeeByFilterAsync(EmployeeFilter employeeFilter);
	Task<Employee> CreateEmployeeAsync(Employee employee);
	Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit);
	Task<Employee> RestoreEmployeeAsync(string employeeId);
	Task RemoveEmployeeAsync(string employeeId);
	Task DeleteEmployeeAsync(string employeeId);
}