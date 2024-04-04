using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership.Controllers;

[Route("warehouse-order")]
[ApiController]
public class WarehouseOrderController : ControllerBase
{
	private ILogger<WarehouseOrderController> Logger { get; }

}
