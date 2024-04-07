
using CarDealership.PersonsAdministration.BLL;
using CarDealership.PersonsAdministration.DAL;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDealership.PersonsAdministration;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		RegisterManagers(builder.Services);
		RegisterRepositories(builder.Services);
		RegisterRegisterRestClient(builder.Services);
		ConfigureServices(builder.Services, builder.Configuration);

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}

	private static void RegisterQueues(IServiceCollection services)
	{

	}

	private static void RegisterRegisterRestClient(IServiceCollection services)
	{
		services.AddHttpClient();
		//services.AddScoped<IChatRestClient, ChatRestClient>();

	}
	private static void RegisterManagers(IServiceCollection services)
	{
		services.AddScoped<ICustomerManager, CustomerManager>();
		services.AddScoped<IEmployeeManager, EmployeeManager>();
		services.AddScoped<IObjectUsageManager, ObjectUsageManager>();
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<IEmployeeRepository, EmployeeRepository>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetSection("SeqUrl").Value);
		});
	}
}
