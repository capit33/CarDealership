using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Controllers;

[Route("warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
	private ILogger<WarehouseController> Logger { get; }

	private IWarehouseManager WarehouseManager { get; }

	public WarehouseController(ILogger<WarehouseController> logger,
		IWarehouseManager warehouseManager)
	{
		Logger = logger;
		WarehouseManager = warehouseManager;
	}

	[HttpGet]
	[Route("{carId}")]
	public async Task<IActionResult> GetCarInWarehouseByIdAsync(string carId)
	{
		try
		{
			return Ok(await WarehouseManager.GetCarInWarehouseByIdAsync(carId));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("filter")]
	public async Task<IActionResult> GetCarsWarehouseByFilterAsync([FromBody] CarFilter carFilter)
	{
		try
		{
			return Ok(await WarehouseManager.GetCarsWarehouseByFilterAsync(carFilter));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
