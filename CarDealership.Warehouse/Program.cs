
using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.DAL;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CarDealership.Warehouse;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		ConfigureServices(builder.Services, builder.Configuration);
		RegisterManagers(builder.Services);
		RegisterRepositories(builder.Services);

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

	private static void RegisterQueues(IServiceCollection services)
	{

	}

	private static void RegisterManagers(IServiceCollection services)
	{
		services.AddScoped<ICarWarehouseManager, CarWarehouseManager>();
		services.AddScoped<ISupplierOrderManager, SupplierOrderManager>();
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<IWarehouseRepository, WarehouseRepository>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetValue<string>("SeqUrl"));
		});
	}
}
