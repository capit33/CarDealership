using CarDealership.PersonsAdministration.Interfaces.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarDealership.PersonsAdministration.Controllers;

[Route("customers")]
[ApiController]
public class CustomerController : ControllerBase
{
	private ILogger<EmployeeController> Logger { get; }
	private ICustomerManager CustomerManager { get; }

	public CustomerController(
		ILogger<EmployeeController> logger, 
		ICustomerManager customerManager)
	{
		Logger = logger;
		CustomerManager = customerManager;
	}



}
