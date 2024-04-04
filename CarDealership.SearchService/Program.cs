
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDealership.SearchService;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);


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
		//services.AddScoped<IChatRestClient, ChatRestClient>();

	}
	private static void RegisterManagers(IServiceCollection services)
	{
		//services.AddScoped<IObjectUsageManager, ObjectUsageManager>();
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		//services.AddScoped<IEmployeeRepository, EmployeeRepository>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetValue<string>("SeqUrl"));
		});
	}
}
