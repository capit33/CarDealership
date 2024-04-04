using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace CarDealership.Warehouse.Controllers;

[Route("purchase-order")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
	private ILogger<PurchaseOrderController> Logger { get; }
	private IPurchaseOrderManager PurchaseOrderManager { get; }

	public PurchaseOrderController(ILogger<PurchaseOrderController> logger, 
		IPurchaseOrderManager purchaseOrderManager)
	{
		Logger = logger;
		PurchaseOrderManager = purchaseOrderManager;
	}

	[HttpGet]
	[Route("{purchaseOrderId}")]
	public async Task<IActionResult> GetPurchaseOrderByIdAsync(string purchaseOrderId)
	{
		try
		{
			return Ok(await PurchaseOrderManager.GetPurchaseOrderByIdAsync(purchaseOrderId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("/status/{status}")]
	public async Task<IActionResult> GetPurchaseOrderByStatusAsync(string status)
	{
		try
		{
			return Ok(await PurchaseOrderManager.GetPurchaseOrderByStatusAsync(status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{purchaseOrderId}/status/{status}")]
	public async Task<IActionResult> EditPurchaseOrderStatusAsync(string purchaseOrderId, string status)
	{
		try
		{
			return Ok(await PurchaseOrderManager.EditPurchaseOrderStatusAsync(purchaseOrderId, status));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
