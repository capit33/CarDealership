using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.SearchService.Controllers;

[Route("search")]
[ApiController]
public class SearchController : ControllerBase
{
	private ILogger<SearchController> Logger { get; }
}
