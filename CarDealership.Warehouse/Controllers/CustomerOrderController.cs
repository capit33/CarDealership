using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

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
	[Route("/status/{status}")]
	public async Task<IActionResult> GetCustomerOrderByStatusAsync(string status)
	{
		try
		{
			return Ok(await CustomerOrderManager.GetCustomerOrderByStatusAsync(status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateCustomerOrderAsync([FromBody] WarehouseCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		try
		{
			return Ok(await CustomerOrderManager.CreateCustomerOrderAsync(warehouseCustomerOrderCreate));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("{customerOrderId}")]
	public async Task<IActionResult> ChangeCustomerOrderAsync(string customerOrderId, [FromBody] WarehouseCustomerOrderEdit customerOrderEdit)
	{
		try
		{
			return Ok(await CustomerOrderManager.EditCustomerOrderByIdAsync(customerOrderId, customerOrderEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("canceled/{customerOrderId}")]
	public async Task<IActionResult> CanceledCustomerOrderAsync(string customerOrderId)
	{
		try
		{
			return Ok(await CustomerOrderManager.CanceledCustomerOrderByIdAsync(customerOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("completed/{customerOrderId}")]
	public async Task<IActionResult> CompletedCustomerOrderAsync(string customerOrderId)
	{
		try
		{
			return Ok(await CustomerOrderManager.CompletedCustomerOrderByIdAsync(customerOrderId));
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
