using CarDealership.CarDealership.BLL;
using CarDealership.CarDealership.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;

namespace CarDealership.CarDealership.Controllers;

[Route("customer-order")]
[ApiController]
public class CustomerOrderController : ControllerBase
{
	private ILogger<CustomerOrderController> Logger { get; }
	private ICustomerOrderManager CustomerOrderManager { get; }

	public CustomerOrderController(ILogger<CustomerOrderController> logger, 
		ICustomerOrderManager customerOrderManager)
	{
		Logger = logger;
		CustomerOrderManager = customerOrderManager;
	}

	[HttpGet]
	[Route("{customerOrderId}")]
	public async Task<IActionResult> GetCustomerOrderByIdAsync(string customerOrderId)
	{
		try
		{
			return Ok(await CustomerOrderManager.GetCustomerOrderByIdAsync(customerOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("status/{status}")]
	public async Task<IActionResult> GetCustomerOrdersByStatusAsync(string status)
	{
		try
		{
			return Ok(await CustomerOrderManager.GetCustomerOrdersByStatusAsync(status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateCustomerOrderAsync([FromBody] CustomerOrderCreate customerOrderCreate)
	{
		try
		{
			return Ok(await CustomerOrderManager.CreateCustomerOrderAsync(customerOrderCreate));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{customerOrderId}")]
	public async Task<IActionResult> EditCustomerOrderAsync(string customerOrderId, [FromBody] CustomerOrderEdit customerOrderEdit)
	{
		try
		{
			return Ok(await CustomerOrderManager.EditCustomerOrderAsync(customerOrderId, customerOrderEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{customerOrderId}/employee/{employeeId}")]
	public async Task<IActionResult> EditCustomerOrderEmployeeIdAsync(string customerOrderId, string employeeId)
	{
		try
		{
			return Ok(await CustomerOrderManager.EditCustomerOrderEmployeeIdAsync(customerOrderId, employeeId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{customerOrderId}/status/canceled")]
	public async Task<IActionResult> CanceledCustomerOrderAsync(string customerOrderId)
	{
		try
		{
			return Ok(await CustomerOrderManager.CanceledCustomerOrderAsync(customerOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{customerOrderId}")]
	public async Task<IActionResult> DeleteCustomerOrderAsync(string customerOrderId)
	{
		try
		{
			await CustomerOrderManager.DeleteCustomerOrderAsync(customerOrderId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
