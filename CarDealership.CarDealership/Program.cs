
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDealership.CarDealership;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

		ConfigureServices(builder.Services, builder.Configuration);
		RegisterManagers(builder.Services);
		RegisterRepositories(builder.Services);

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

	}

	private static void RegisterRepositories(IServiceCollection services)
	{

	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetValue<string>("SeqUrl"));
		});
	}
}
