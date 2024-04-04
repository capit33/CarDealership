using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Enum;

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
	[Route("{supplierOrderId}/status/{status}")]
	public async Task<IActionResult> EditSupplierOrderAsync(string supplierOrderId, string status)
	{
		try
		{
			return Ok(await SupplierOrderManager.ChangeSupplierOrderStutusAsync(supplierOrderId, status));
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
			return Ok(await SupplierOrderManager.DeleteSupplierOrderAsync(supplierOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
