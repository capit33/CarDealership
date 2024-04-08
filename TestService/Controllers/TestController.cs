using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using TestService.Interface;

namespace TestService.Controllers;

[Route("test")]
[ApiController]
public class TestController : ControllerBase
{
	private ITestManager TestManager { get; set; }
	private ILogger<TestController> Logger { get; }

	public TestController(ITestManager testManager, 
		ILogger<TestController> logger)
	{
		TestManager = testManager;
		Logger = logger;
	}

	#region WarehouseRestClient

	[HttpGet]
	[Route("warehouse-car-warehouse")]
	public async Task<IActionResult> WarehouseCarWarehouseAsync()
	{
		try
		{
			await TestManager.WarehouseCarWarehouseAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("warehouse-client")]
	public async Task<IActionResult> WarehouseClientAsync()
	{
		try
		{
			await TestManager.WarehouseClientAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("warehouse-warehouse-customer-order")]
	public async Task<IActionResult> WarehouseCustomerOrderAsync()
	{
		try
		{
			await TestManager.WarehouseCustomerOrderAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("warehouse-purchase-order")]
	public async Task<IActionResult> WarehousePurchaseOrderAsync()
	{
		try
		{
			await TestManager.WarehousePurchaseOrderAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("warehouse-supplier-order")]
	public async Task<IActionResult> WarehouseSupplierOrderAsync()
	{
		try
		{
			await TestManager.WarehouseSupplierOrderAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}


	#endregion

	#region PersonsAdministrationRestClient

	[HttpGet]
	[Route("person-administration-customers")]
	public async Task<IActionResult> PersonCustomerAsync()
	{
		try
		{
			await TestManager.PersonCustomerAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("person-administration-employees")]
	public async Task<IActionResult> PersonEmployeeAsync()
	{
		try
		{
			await TestManager.PersonEmployeeAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	#endregion

	#region CarDealershipRestClient

	[HttpGet]
	[Route("car-dealership-customer-order")]
	public async Task<IActionResult> CarDealershipCustomerOrderAsync()
	{
		try
		{
			await TestManager.CarDealershipCustomerOrderAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("car-dealership-search")]
	public async Task<IActionResult> CarDealershipSearchAsync()
	{
		try
		{
			await TestManager.CarDealershipSearchAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("car-dealership-warehouse")]
	public async Task<IActionResult> CarDealershipWarehouseAsync()
	{
		try
		{
			await TestManager.CarDealershipWarehouseAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[Route("car-dealership-warehouse-order")]
	public async Task<IActionResult> CarDealershipWarehouseOrderAsync()
	{
		try
		{
			await TestManager.CarDealershipWarehouseOrderAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, ex.Message, ex.StackTrace);
			return BadRequest(ex.Message);
		}
	}
	#endregion
}
