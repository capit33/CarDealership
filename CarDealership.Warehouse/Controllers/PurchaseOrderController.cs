using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

	[HttpDelete]
	[Route("{purchaseOrderId}")]
	public async Task<IActionResult> DeletePurchaseOrderAsync(string purchaseOrderId)
	{
		try
		{
			await PurchaseOrderManager.DeletePurchaseOrderAsync(purchaseOrderId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
