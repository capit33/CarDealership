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

	[HttpPut]
	[Route("car-dealership-order/{carDealershipOrderId}")]
	public async Task<IActionResult> ChangeCustomerOrderAsync(string carDealershipOrderId, [FromBody] WarehouseCustomerOrderEdit customerOrderEdit)
	{
		try
		{
			return Ok(await CustomerOrderManager.ChangeCustomerOrderAsync(carDealershipOrderId, customerOrderEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{customerOrderId}/status/{status}")]
	public async Task<IActionResult> ChangeCustomerOrderStatusAsync(string customerOrderId, string status)
	{
		try
		{
			return Ok(await CustomerOrderManager.ChangeCustomerOrderStatusAsync(customerOrderId, status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
