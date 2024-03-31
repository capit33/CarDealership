using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

[Route("warehouse-customer-order")]
[ApiController]
public class CustomerOrdersController : ControllerBase
{
	public ICustomerOrdersManager CustomerOrdersManager { get; set; }
	private ILogger<CustomerOrdersController> Logger { get; }

	public CustomerOrdersController(ICustomerOrdersManager customerOrdersManager, ILogger<CustomerOrdersController> logger)
	{
		CustomerOrdersManager = customerOrdersManager;
		Logger = logger;
	}

	[HttpGet]
	[Route("open")]
	public async Task<IActionResult> GetOpenOrdersAsync()
	{
		try
		{
			return Ok(await CustomerOrdersManager.GetOpenOrdersAsync());
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("completed/{orderId}")]
	public async Task<IActionResult> OrderCompletedAsync(string orderId)
	{
		try
		{
			return Ok(await CustomerOrdersManager.OrderCompletedAsync(orderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
