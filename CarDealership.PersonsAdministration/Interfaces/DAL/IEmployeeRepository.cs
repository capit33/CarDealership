using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Employee;
using CarDealership.Contracts.Model.Person.Employee.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.DAL;

public interface IEmployeeRepository
	{
		Task<Employee> GetEmployeeByIdAsync(string employeeId);
		Task<List<Employee>> GetEmployeesByFilterAsync(EmployeeFilter employeeFilter);
		Task<long> GetEmployeeCountByFilterAsync(EmployeeFilter employeeFilter);
		Task<Employee> CreateEmployeeAsync(Employee employee);
		Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit);
		Task<Employee> ChangeEmployeeRemoveStatusAsync(string employeeId, bool removeStatus);
		Task DeleteEmployeeAsync(string employeeId);
	}