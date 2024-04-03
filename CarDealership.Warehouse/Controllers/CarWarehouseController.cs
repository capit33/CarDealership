using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Customer;
using CarDealership.Contracts.Model.Warehouse;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Controllers;

[Route("car-warehouse")]
[ApiController]
public class CarWarehouseController : ControllerBase
{
	public IWarehouseManager WarehouseManager { get; set; }
	private ILogger<CarWarehouseController> Logger { get; }

	public CarWarehouseController(IWarehouseManager warehouseManager, ILogger<CarWarehouseController> logger)
	{
		WarehouseManager = warehouseManager;
		Logger = logger;
	}

	[HttpGet]
	[Route("available")]
	public async Task<IActionResult> GetAvailableCarsAsync()
	{
		try
		{
			return Ok(await WarehouseManager.GetAvailableCarsAsync());
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	[Route("filter")]
	public async Task<IActionResult> GetCarsByFilterAsync([FromBody] CarFilter carFilter)
	{
		try
		{
			return Ok(await WarehouseManager.GetCarsByFilterAsync(carFilter));
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
