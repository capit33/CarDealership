using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Contracts.Model.WarehouseModel.DTO;

namespace CarDealership.Warehouse.Controllers;

[Route("client")]
[ApiController]
public class ClientController : ControllerBase
{
	private ILogger<CarWarehouseController> Logger { get; }
	private ICarWarehouseManager CarWarehouseManager { get; }
	private ICustomerOrderManager CustomerOrderManager { get; }

	public ClientController(ILogger<CarWarehouseController> logger, 
		ICarWarehouseManager carWarehouseManager, 
		ICustomerOrderManager customerOrderManager)
	{
		Logger = logger;
		CarWarehouseManager = carWarehouseManager;
		CustomerOrderManager = customerOrderManager;
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

	[HttpPut]
	[Route("car-dealership-order/{carDealershipOrderId}")]
	public async Task<IActionResult> ChangeCustomerOrderAsync(string carDealershipOrderId, [FromBody] WarehouseCustomerOrderEdit customerOrderEdit)
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
}
