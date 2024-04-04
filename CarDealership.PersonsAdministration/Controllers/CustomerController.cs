using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Controllers;

[Route("customers")]
[ApiController]
public class CustomerController : ControllerBase
{
	private ILogger<CustomerController> Logger { get; }
	private ICustomerManager CustomerManager { get; }

	public CustomerController(
		ILogger<CustomerController> logger, 
		ICustomerManager customerManager)
	{
		Logger = logger;
		CustomerManager = customerManager;
	}

	[HttpGet]
	[Route("{customerId}")]
	public async Task<IActionResult> GetCustomerAsync(string customerId)
	{
		try
		{
			return Ok(await CustomerManager.GetCustomerByIdAsync(customerId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("filter")]
	public async Task<IActionResult> GetCustomerByFilterAsync([FromBody] CustomerFilter customerFilter)
	{
		try
		{
			return Ok(await CustomerManager.GetCustomerByFilterAsync(customerFilter));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
	{
		try
		{
			return Ok(await CustomerManager.CreateCustomerAsync(customer));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{customerId}")]
	public async Task<IActionResult> EditCustomerAsync(string customerId, [FromBody] CustomerEdit customerEdit)
	{
		try
		{
			return Ok(await CustomerManager.EditCustomerAsync(customerId, customerEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("restore/{customerId}")]
	public async Task<IActionResult> RestoreCustomerAsync(string customerId)
	{
		try
		{
			return Ok(await CustomerManager.RestoreCustomerAsync(customerId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}


	[HttpPut]
	[Route("remove/{customerId}")]
	public async Task<IActionResult> RemoveCustomerAsync(string customerId)
	{
		try
		{
			await CustomerManager.RemoveCustomerAsync(customerId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{customerId}")]
	public async Task<IActionResult> DeleteCustomerAsync(string customerId)
	{
		try
		{
			await CustomerManager.DeleteCustomerAsync(customerId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

}
