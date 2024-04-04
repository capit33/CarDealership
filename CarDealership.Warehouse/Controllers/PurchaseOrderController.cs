using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.Warehouse.Controllers;

[Route("purchase-order")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
	private ILogger<PurchaseOrderController> Logger { get; }

}
