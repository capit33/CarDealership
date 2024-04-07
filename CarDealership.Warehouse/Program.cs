using CarDealership.Warehouse.BLL;
using CarDealership.Warehouse.DAL;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using CarDealership.Warehouse.Interfaces.MessageBroker;
using CarDealership.Warehouse.MessageBroker.Consumers;
using CarDealership.Warehouse.MessageBroker.Publishers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDealership.Warehouse;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		ConfigureServices(builder.Services, builder.Configuration);
		RegisterManagers(builder.Services);
		RegisterRepositories(builder.Services);
		RegisterMessageBrokers(builder.Services, builder.Configuration);

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

	private static void RegisterMessageBrokers(IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IPurchaseOrderStatusQueuePublisher, PurchaseOrderStatusQueuePublisher>();
		services.AddScoped<ICustomerOrderStatusQueuePublisher, CustomerOrderStatusQueuePublisher>();

		services.AddMassTransit(x =>
		{
			x.SetKebabCaseEndpointNameFormatter();

			x.AddConsumer<CustomerOrderStatusQueueConsumer>();
			x.AddConsumer<PurchaseOrderQueueConsumer>();

			x.UsingRabbitMq((context, cfg) =>
			{
				cfg.Host(configuration.GetSection("RabbitMQ:Uri").Value);

				cfg.ReceiveEndpoint("car-dealership-customer-order-status-queue", e =>
				{
					e.ConfigureConsumer<CustomerOrderStatusQueueConsumer>(context);
				});

				cfg.ReceiveEndpoint("car-dealership-purchase-order-queue", e =>
				{
					e.ConfigureConsumer<PurchaseOrderQueueConsumer>(context);
				});

				cfg.ClearSerialization();
				cfg.UseRawJsonSerializer();
				cfg.ConfigureEndpoints(context);
			});
		});
	}

	private static void RegisterManagers(IServiceCollection services)
	{
		services.AddScoped<ICarWarehouseManager, CarWarehouseManager>();
		services.AddScoped<ISupplierOrderManager, SupplierOrderManager>();
		services.AddScoped<IPurchaseOrderManager, PurchaseOrderManager>();
		services.AddScoped<ICustomerOrderManager, CustomerOrderManager>();
		services.AddScoped<IChangeOrderStatusManager, ChangeOrderStatusManager>();
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<ICarWarehouseRepository, CarWarehouseRepository>();
		services.AddScoped<ISupplierOrderRepository, SupplierOrderRepository>();
		services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
		services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddLogging(loggingBuilder =>
		{
			loggingBuilder.AddSeq(configuration.GetSection("SeqUrl").Value);
		});
	}
}
