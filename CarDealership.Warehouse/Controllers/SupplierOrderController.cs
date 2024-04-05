using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

[Route("supplier-order")]
[ApiController]
public class SupplierOrderController : ControllerBase
{
	private ILogger<SupplierOrderController> Logger { get; }
	private ISupplierOrderManager SupplierOrderManager { get; }

	public SupplierOrderController(ILogger<SupplierOrderController> logger,
		ISupplierOrderManager supplierOrderManager)
	{
		Logger = logger;
		SupplierOrderManager = supplierOrderManager;
	}

	[HttpGet]
	[Route("{supplierOrderId}")]
	public async Task<IActionResult> GetSupplierOrderByIdAsync(string supplierOrderId)
	{
		try
		{
			return Ok(await SupplierOrderManager.GetSupplierOrderByIdAsync(supplierOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("/status/{status}")]
	public async Task<IActionResult> GetSupplierOrderByStatusAsync(string status)
	{
		try
		{
			return Ok(await SupplierOrderManager.GetSupplierOrderByStatusAsync(status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateSupplierOrderAsync([FromBody] WarehouseSupplierOrderDTO supplierOrder)
	{
		try
		{
			return Ok(await SupplierOrderManager.CreateSupplierOrderAsync(supplierOrder));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("")]
	public async Task<IActionResult> EditSupplierOrderAsync([FromBody] WarehouseSupplierOrderDTO supplierOrder)
	{
		try
		{
			return Ok(await SupplierOrderManager.EditSupplierOrderAsync(supplierOrder));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("arrival-car")]
	public async Task<IActionResult> ArrivalCarAsync([FromBody] ArrivalCar arrivalCar)
	{
		try
		{
			return Ok(await SupplierOrderManager.ArrivalCarAsync(arrivalCar));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{supplierOrderId}/status/{status}")]
	public async Task<IActionResult> EditSupplierOrderStatusAsync(string supplierOrderId, string status)
	{
		try
		{
			return Ok(await SupplierOrderManager.ChangeSupplierOrderStatusAsync(supplierOrderId, status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{supplierOrderId}")]
	public async Task<IActionResult> EditSupplierOrderAsync(string supplierOrderId)
	{
		try
		{
			await SupplierOrderManager.DeleteSupplierOrderAsync(supplierOrderId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
