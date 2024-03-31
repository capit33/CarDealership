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

[Route("warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
	public IWarehouseManager WarehouseManager { get; set; }
	private ILogger<WarehouseController> Logger { get; }

	public WarehouseController(IWarehouseManager warehouseManager, ILogger<WarehouseController> logger)
	{
		WarehouseManager = warehouseManager;
		Logger = logger;
	}

	[HttpGet]
	[Route("")]
	public async Task<IActionResult> GetCarsInWarehouseAsync()
	{
		try
		{
			return Ok(await WarehouseManager.GetCarsInWarehouseAsync());
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
