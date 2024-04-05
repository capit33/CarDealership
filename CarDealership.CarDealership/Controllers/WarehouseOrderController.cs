using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.Contracts.Model.CarDealershipModel.Orders.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Controllers;

[Route("warehouse-order")]
[ApiController]
public class WarehouseOrderController : ControllerBase
{
	private ILogger<WarehouseOrderController> Logger { get; }
	private IWarehouseOrderManager WarehouseOrderManager { get; }

	public WarehouseOrderController(ILogger<WarehouseOrderController> logger,
		IWarehouseOrderManager warehouseOrderManager)
	{
		Logger = logger;
		WarehouseOrderManager = warehouseOrderManager;
	}

	[HttpGet]
	[Route("{warehouseOrderId}")]
	public async Task<IActionResult> GetCustomerOrderByIdAsync(string warehouseOrderId)
	{
		try
		{
			return Ok(await WarehouseOrderManager.GetWarehouseOrderByIdAsync(warehouseOrderId));
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
			return Ok(await WarehouseOrderManager.GetWarehouseOrdersByStatusAsync(status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateWarehouseOrderAsync([FromBody] WarehouseOrderCreate warehouseOrderCreate)
	{
		try
		{
			return Ok(await WarehouseOrderManager.CreateWarehouseOrderAsync(warehouseOrderCreate));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{warehouseOrderId}/employee/{employeeId}")]
	public async Task<IActionResult> EditWarehouseOrderEmployeeIdAsync(string warehouseOrderId, string employeeId)
	{
		try
		{
			return Ok(await WarehouseOrderManager.EditWarehouseOrderEmployeeIdAsync(warehouseOrderId, employeeId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{warehouseOrderId}/status/canceled")]
	public async Task<IActionResult> CanceledWarehouseOrderAsync(string warehouseOrderId)
	{
		try
		{
			return Ok(await WarehouseOrderManager.CanceledWarehouseOrderAsync(warehouseOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{warehouseOrderId}")]
	public async Task<IActionResult> DeleteWarehouseOrderAsync(string warehouseOrderId)
	{
		try
		{
			await WarehouseOrderManager.DeleteWarehouseOrderAsync(warehouseOrderId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
