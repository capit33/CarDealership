﻿using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker;
using CarDealership.Warehouse.Interfaces.BLL;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.MessageBroker.Consumers;

public class CustomerOrderStatusQueueConsumer
	: BaseConsumer<CarDealershipCustomerOrderStatusQueue, CustomerOrderStatusQueueConsumer>
{
	private ICustomerOrderManager CustomerOrderManager { get; set; }

	public CustomerOrderStatusQueueConsumer(ILogger<CustomerOrderStatusQueueConsumer> logger,
		ICustomerOrderManager customerOrderManager)
		: base(logger)
	{
		CustomerOrderManager = customerOrderManager;
	}

	public override async Task HandleMessageAsync(CarDealershipCustomerOrderStatusQueue message)
	{
		if (message != null)
		{
			if (message.DocumentStatus == DocumentStatus.Canceled)
			{
				await CustomerOrderManager.CanceledCustomerOrderByCarDealershipIdAsync(message.CarDealershipOrderId);
			}
		}
	}
}
