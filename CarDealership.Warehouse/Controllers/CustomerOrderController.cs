using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CarDealership.Contracts.Model.WarehouseModel.DTO;

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

	[HttpPut]
	[Route("status/{status}")]
	public async Task<IActionResult> ChangeCustomerOrderStatusAsync([FromBody] CustomerOrderEdit customerOrderEdit, string status)
	{
		try
		{
			return Ok(await CustomerOrderManager.ChangeCustomerOrderStatusAsync(customerOrderEdit, status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
