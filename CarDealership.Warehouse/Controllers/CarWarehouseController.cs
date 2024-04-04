﻿using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Customer;
<<<<<<< HEAD
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
=======
using CarDealership.Contracts.Model.Warehouse;
>>>>>>> fa08f945cb51894383ec824d32e632393fe6e72f
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
<<<<<<< HEAD
	public ICarWarehouseManager CarWarehouseManager { get; set; }
	private ILogger<CarWarehouseController> Logger { get; }

	public CarWarehouseController(ICarWarehouseManager warehouseManager, 
		ILogger<CarWarehouseController> logger)
	{
		CarWarehouseManager = warehouseManager;
=======
	public IWarehouseManager WarehouseManager { get; set; }
	private ILogger<CarWarehouseController> Logger { get; }

	public CarWarehouseController(IWarehouseManager warehouseManager, ILogger<CarWarehouseController> logger)
	{
		WarehouseManager = warehouseManager;
>>>>>>> fa08f945cb51894383ec824d32e632393fe6e72f
		Logger = logger;
	}

	[HttpGet]
	[Route("available")]
<<<<<<< HEAD
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
			return Ok(await CarWarehouseManager.GetCarByIdAsync(carId));
=======
	public async Task<IActionResult> GetAvailableCarsAsync()
	{
		try
		{
			return Ok(await WarehouseManager.GetAvailableCarsAsync());
>>>>>>> fa08f945cb51894383ec824d32e632393fe6e72f
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpPost]
<<<<<<< HEAD
	[Route("available/filter")]
=======
	[Route("filter")]
>>>>>>> fa08f945cb51894383ec824d32e632393fe6e72f
	public async Task<IActionResult> GetCarsByFilterAsync([FromBody] CarFilter carFilter)
	{
		try
		{
<<<<<<< HEAD
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
	public async Task<IActionResult> CreateCarAsync([FromBody] CarFile carFile)
	{
		try
		{
			return Ok(await CarWarehouseManager.CreateCarAsync(carFile));
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
			return Ok(await CarWarehouseManager.DeleteCarAsync(carId));
=======
			return Ok(await WarehouseManager.GetCarsByFilterAsync(carFilter));
>>>>>>> fa08f945cb51894383ec824d32e632393fe6e72f
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
}
