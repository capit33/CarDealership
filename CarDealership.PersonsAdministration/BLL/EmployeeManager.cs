using CarDealership.Contracts;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.BLL;

public class EmployeeManager : IEmployeeManager
{
	public IEmployeeRepository EmployeeRepository { get; }
	public IObjectUsageManager ObjectUsageManager { get; }
	
	public EmployeeManager(
		IEmployeeRepository employeeRepository,
		IObjectUsageManager objectUsageManager)
	{
		EmployeeRepository = employeeRepository;
		ObjectUsageManager = objectUsageManager;
	}

	public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
	{
		if (string.IsNullOrWhiteSpace(employeeId))
			throw new ArgumentNullException(nameof(employeeId));

		return await EmployeeRepository.GetEmployeeByIdAsync(employeeId);
	}

	public async Task<PageItems<Employee>> GetEmployeeByFilterAsync(EmployeeFilter employeeFilter)
	{
		if (employeeFilter == null)
			throw new ArgumentNullException(nameof(employeeFilter));

		var isValid = employeeFilter.IsPaginationValid(out string message);
		
		if (!isValid)
			throw new InvalidDataException(message);

		var pageItems = new PageItems<Employee>(employeeFilter);

		var employeesCount = await EmployeeRepository.GetEmployeeCountByFilterAsync(employeeFilter);

        if (employeesCount == 0)
			return pageItems;

		pageItems.PageCount = (int)Math.Ceiling((double)employeesCount / pageItems.PageSize);
		pageItems.Items = await EmployeeRepository.GetEmployeesByFilterAsync(employeeFilter);

        return pageItems;
	}

	public async Task<Employee> CreateEmployeeAsync(Employee employee)
	{
		if (employee == null)
			throw new ArgumentNullException(nameof(employee));

		if (!employee.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		return await EmployeeRepository.CreateEmployeeAsync(employee);
	}

	public async Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit)
	{
		if (string.IsNullOrWhiteSpace(employeeId))
			throw new ArgumentNullException(nameof(employeeId));

		if (employeeEdit == null)
			throw new ArgumentNullException(nameof(employeeEdit));

		if (employeeEdit.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);
		
		return await EmployeeRepository.EditEmployeeAsync(employeeId, employeeEdit);
	}

	public async Task<Employee> RestoreEmployeeAsync(string employeeId)
	{
		if (string.IsNullOrWhiteSpace(employeeId))
			throw new ArgumentNullException(nameof(employeeId));

		return await EmployeeRepository.ChangeEmployeeRemoveStatusAsync(employeeId, false);
	}

	public async Task RemoveEmployeeAsync(string employeeId)
	{
		if (string.IsNullOrWhiteSpace(employeeId))
			throw new ArgumentNullException(nameof(employeeId));

		await EmployeeRepository.ChangeEmployeeRemoveStatusAsync(employeeId, true);
	}

	public async Task DeleteEmployeeAsync(string employeeId)
	{
		var isUsing = await ObjectUsageManager.IsEmployeeIdUsedAsync(employeeId);
		if (isUsing)
			new Exception($"{nameof(employeeId)}: {employeeId} {ConstantMessages.DeleteError}");

		await EmployeeRepository.DeleteEmployeeAsync(employeeId);
	}
}
