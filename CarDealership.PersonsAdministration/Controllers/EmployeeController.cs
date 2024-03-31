using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Employee;
using CarDealership.Contracts.Model.Person.Employee.DTO;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Controllers;

[Route("employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
	private ILogger<EmployeeController> Logger { get; }
	private IEmployeeManager EmployeeManager { get; }

	public EmployeeController(
		ILogger<EmployeeController> logger,
		IEmployeeManager employeeManager)
	{
		Logger = logger;
		EmployeeManager = employeeManager;
	}

	[HttpGet]
	[Route("{employeeId}")]
	public async Task<IActionResult> GetEmployeeAsync(string employeeId)
	{
		try
		{
			return Ok(await EmployeeManager.GetEmployeeByIdAsync(employeeId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("filter")]
	public async Task<IActionResult> GetEmployeeByFilterAsync([FromBody] EmployeeFilter employeeFilter)
	{
		try
		{
			return Ok(await EmployeeManager.GetEmployeeByFilterAsync(employeeFilter));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateEmployeeAsync([FromBody] Employee employee)
	{
		try
		{
			return Ok( await EmployeeManager.CreateEmployeeAsync(employee));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{employeeId}")]
	public async Task<IActionResult> EditEmployeeAsync(string employeeId, [FromBody] EmployeeEdit employeeEdit)
	{
		try
		{
			return Ok(await EmployeeManager.EditEmployeeAsync(employeeId, employeeEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("restore/{employeeId}")]
	public async Task<IActionResult> RestoreEmployeeAsync(string employeeId)
	{
		try
		{
			return Ok(await EmployeeManager.RestoreEmployeeAsync(employeeId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}


	[HttpPut]
	[Route("remove/{employeeId}")]
	public async Task<IActionResult> RemoveEmployeeAsync(string employeeId)
	{
		try
		{
			await EmployeeManager.RemoveEmployeeAsync(employeeId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{employeeId}")]
	public async Task<IActionResult> DeleteEmployeeAsync(string employeeId)
	{
		try
		{
			await EmployeeManager.DeleteEmployeeAsync(employeeId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
