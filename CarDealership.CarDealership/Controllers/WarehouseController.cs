using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership.Controllers;

[Route("warehouse")]
[ApiController]
public class WarehouseController : ControllerBase
{
	private ILogger<WarehouseController> Logger { get; }


}
