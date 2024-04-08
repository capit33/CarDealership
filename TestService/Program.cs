
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestService.BLL;
using TestService.Interface;
using TestService.RestClient;

namespace TestService;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		RegisterManagers(builder.Services);
		RegisterRegisterRestClient(builder.Services);
		ConfigureServices(builder.Services, builder.Configuration);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

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

	private static void RegisterRegisterRestClient(IServiceCollection services)
	{
		services.AddHttpClient();
		services.AddScoped<IPersonsAdministrationRestClient, PersonsAdministrationRestClient>();
		services.AddScoped<IWarehouseRestClient, WarehouseRestClient>();
		services.AddScoped<ICarDealershipRestClient, CarDealershipRestClient>();

	}

	private static void RegisterManagers(IServiceCollection services)
	{
		services.AddScoped<ITestManager, TestManager>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetSection("SeqUrl").Value);
		});
	}
}
