
using CarDealership.CarDealership.BLL;
using CarDealership.CarDealership.DAL;
using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.DAL;
using CarDealership.CarDealership.Interfaces.MessageBroker;
using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.CarDealership.MessageBroker.Consumers;
using CarDealership.CarDealership.MessageBroker.Publishers;
using CarDealership.CarDealership.RestClients;
using MassTransit;
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
		RegisterRegisterRestClient(builder.Services);
		RegisterMessageBrokers(builder.Services, builder.Configuration);



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
	private static void RegisterMessageBrokers(IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IPurchaseOrderQueuePublisher, PurchaseOrderQueuePublisher>();
		services.AddScoped<ICustomerOrderStatusQueuePublisher, CustomerOrderStatusQueuePublisher>();

		services.AddMassTransit(x =>
		{
			x.SetKebabCaseEndpointNameFormatter();

			x.AddConsumer<CustomerOrderStatusQueueConsumer>();
			x.AddConsumer<PurchaseOrderStatusQueueConsumer>();

			x.UsingRabbitMq((context, cfg) =>
			{
				cfg.Host(configuration.GetSection("RabbitMQ:Uri").Value);

				cfg.ReceiveEndpoint("warehouse-customer-order-status-queue", e =>
				{
					e.ConfigureConsumer<CustomerOrderStatusQueueConsumer>(context);
				});

				cfg.ReceiveEndpoint("warehouse-purchase-order-status-queue", e =>
				{
					e.ConfigureConsumer<PurchaseOrderStatusQueueConsumer>(context);
				});

				cfg.ClearSerialization();
				cfg.UseRawJsonSerializer();
				cfg.ConfigureEndpoints(context);
			});
		});
	}

	private static void RegisterRegisterRestClient(IServiceCollection services)
	{
		services.AddHttpClient();
		services.AddScoped<IPersonsAdministrationRestClient, PersonsAdministrationRestClient>();
		services.AddScoped<IWarehouseRestClient, WarehouseRestClient>();
	}

	private static void RegisterManagers(IServiceCollection services)
	{
		services.AddScoped<ICustomerOrderManager, CustomerOrderManager>();
		services.AddScoped<IWarehouseOrderManager, WarehouseOrderManager>();
		services.AddScoped<IWarehouseManager, WarehouseManager>();
		services.AddScoped<ISearchManager, SearchManager>();
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
		services.AddScoped<IWarehouseOrderRepository, WarehouseOrderRepository>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetSection("SeqUrl").Value);
		});
	}
}
