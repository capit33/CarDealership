using CarDealership.CarDealership.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Controllers;

[Route("search")]
[ApiController]
public class SearchController : ControllerBase
{
	private ILogger<SearchController> Logger { get; }
	private ISearchManager SearchManager { get; }

	public SearchController(ILogger<SearchController> logger, 
		ISearchManager searchManager)
	{
		Logger = logger;
		SearchManager = searchManager;
	}

	[HttpGet]
	[Route("customer/{customerId}")]
	public async Task<IActionResult> FindCustomerIdAsync(string customerId)
	{
		try
		{
			return Ok(await SearchManager.FindCustomerIdAsync(customerId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("employee/{employeeId}")]
	public async Task<IActionResult> FindEmployeeIdAsync(string employeeId)
	{
		try
		{
			return Ok(await SearchManager.FindEmployeeIdAsync(employeeId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
