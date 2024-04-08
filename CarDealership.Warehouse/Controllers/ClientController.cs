using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

[Route("client")]
[ApiController]
public class ClientController : ControllerBase
{
	private ILogger<CarWarehouseController> Logger { get; }
	private ICarWarehouseManager CarWarehouseManager { get; }
	private ICustomerOrderManager CustomerOrderManager { get; }
	private IPurchaseOrderManager PurchaseOrderManager { get; }

	public ClientController(ILogger<CarWarehouseController> logger,
		ICarWarehouseManager carWarehouseManager,
		ICustomerOrderManager customerOrderManager,
		IPurchaseOrderManager purchaseOrderManager)
	{
		Logger = logger;
		CarWarehouseManager = carWarehouseManager;
		CustomerOrderManager = customerOrderManager;
		PurchaseOrderManager = purchaseOrderManager;
	}

	[HttpGet]
	[Route("car/{carId}")]
	public async Task<IActionResult> GetCarByIdAsync(string carId)
	{
		try
		{
			return Ok(await CarWarehouseManager.GetCarInfoByIdAsync(carId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("car/filter")]
	public async Task<IActionResult> GetCarsByFilterAsync([FromBody] CarFilter carFilter)
	{
		try
		{
			return Ok(await CarWarehouseManager.GetCarsByFilterAsync(carFilter, InventoryStatus.Available.ToString()));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("customer-order/create")]
	public async Task<IActionResult> CreateCustomerOrderAsync([FromBody] WarehouseCarDealershipCustomerOrderCreate warehouseCustomerOrderCreate)
	{
		try
		{
			return Ok(await CustomerOrderManager.CreateCustomerOrderCarDealershipAsync(warehouseCustomerOrderCreate));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("customer-order/edit/{carDealershipOrderId}")]
	public async Task<IActionResult> EditCustomerOrderAsync(string carDealershipOrderId, [FromBody] WarehouseCustomerOrderEdit customerOrderEdit)
	{
		try
		{
			return Ok(await CustomerOrderManager.EditCustomerOrderCarDealershipIdAsync(carDealershipOrderId, customerOrderEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	[Route("purchase-order/canceled/{carDealershipOrderId}")]
	public async Task<IActionResult> CanceledPurchaseOrderAsync(string carDealershipOrderId)
	{
		try
		{
			await PurchaseOrderManager.CanceledPurchaseOrderCarDealershipAsync(carDealershipOrderId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
