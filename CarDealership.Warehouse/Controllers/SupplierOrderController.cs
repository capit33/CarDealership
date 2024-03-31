using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CarDealership.Contracts.Model.Warehouse.DTO;

namespace CarDealership.Warehouse.Controllers;

[Route("supplier-order")]
[ApiController]
public class SupplierOrderController : ControllerBase
{
	private ILogger<SupplierOrderController> Logger { get; }
	private ISupplierOrderManager SupplierOrderManager { get; }

	public SupplierOrderController(ILogger<SupplierOrderController> logger, ISupplierOrderManager supplierOrderManager)
	{
		Logger = logger;
		SupplierOrderManager = supplierOrderManager;
	}

	[HttpGet]
	[Route("open")]
	public async Task<IActionResult> GetOpenOrdersAsync()
	{
		try
		{
			return Ok(await SupplierOrderManager.GetOpenOrdersAsync());
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("completed/{orderId}")]
	public async Task<IActionResult> OrderCompletedAsync(string orderId, [FromBody] VINumber number)
	{
		try
		{
			return Ok(await SupplierOrderManager.OrderCompletedAsync(orderId, number));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
