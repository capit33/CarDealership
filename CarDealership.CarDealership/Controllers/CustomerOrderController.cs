using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership.Controllers;

[Route("customer-order")]
[ApiController]
public class CustomerOrderController : ControllerBase
{
	private ILogger<CustomerOrderController> Logger { get; }
}
