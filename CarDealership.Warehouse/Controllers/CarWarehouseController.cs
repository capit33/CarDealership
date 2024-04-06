using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

[Route("car-warehouse")]
[ApiController]
public class CarWarehouseController : ControllerBase
{
	private ICarWarehouseManager CarWarehouseManager { get; set; }
	private ILogger<CarWarehouseController> Logger { get; }

	public CarWarehouseController(ICarWarehouseManager warehouseManager,
		ILogger<CarWarehouseController> logger)
	{
		CarWarehouseManager = warehouseManager;
		Logger = logger;
	}

	[HttpGet]
	[Route("available")]
	public async Task<IActionResult> GetAvailableCarAsync()
	{
		try
		{
			return Ok(await CarWarehouseManager.GetAvailableCarsAsync());
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("{carId}")]
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
	[Route("available/filter")]

	public async Task<IActionResult> GetCarsByFilterAsync([FromBody] CarFilter carFilter)
	{
		try
		{
			return Ok(await CarWarehouseManager.GetCarsByFilterAsync(carFilter));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("")]
	public async Task<IActionResult> CreateCarAsync([FromBody] CarFileCreate carCreate)
	{
		try
		{
			return Ok(await CarWarehouseManager.CreateCarAsync(carCreate));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("{carId}")]
	public async Task<IActionResult> EditCarAsync(string carId, [FromBody] CarFileEdit carFileEdit)
	{
		try
		{
			return Ok(await CarWarehouseManager.EditCarAsync(carId, carFileEdit));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	[Route("{carId}")]
	public async Task<IActionResult> EditCarAsync(string carId)
	{
		try
		{
			await CarWarehouseManager.DeleteCarAsync(carId);
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
