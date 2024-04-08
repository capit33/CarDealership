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
	[Route("status/{status}")]
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
	public async Task<IActionResult> CreateSupplierOrderAsync([FromBody] WarehouseSupplierOrderCreate supplierOrder)
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

	[HttpPatch]
	[Route("processing/{supplierOrderId}")]
	public async Task<IActionResult> SupplierOrderProcessingAsync(string supplierOrderId, [FromBody] SupplierOrderConfirm supplierOrderConfirm)
	{
		try
		{
			return Ok(await SupplierOrderManager.SupplierOrderProcessingAsync(supplierOrderId, supplierOrderConfirm));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("{supplierOrderId}")]
	public async Task<IActionResult> EditSupplierOrderAsync(string supplierOrderId, [FromBody] WarehouseSupplierOrderEdit supplierOrderEdit)
	{
		try
		{
			return Ok(await SupplierOrderManager.EditSupplierOrderAsync(supplierOrderId, supplierOrderEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("arrival-car/{supplierOrderId}/VIN/{VIN}")]
	public async Task<IActionResult> ArrivalCarAsync(string supplierOrderId, string VIN)
	{
		try
		{
			return Ok(await SupplierOrderManager.ArrivalCarAsync(supplierOrderId, VIN));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("canceled/{supplierOrderId}")]
	public async Task<IActionResult> CanceledSupplierOrderAsync(string supplierOrderId)
	{
		try
		{
			return Ok(await SupplierOrderManager.CanceledSupplierOrderAsync(supplierOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{supplierOrderId}")]
	public async Task<IActionResult> DeleteSupplierOrderAsync(string supplierOrderId)
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
