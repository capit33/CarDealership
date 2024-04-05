﻿using CarDealership.Contracts.Model.QueueModel;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure.MessageBroker;

public class BaseConsumer<T, TY> : IConsumer<T>
	where T : BaseQueueMessage, new()
{
	public ILogger<TY> Logger { get; }
	public BaseConsumer(ILogger<TY> logger)
	{
		Logger = logger;
	}

	public async Task Consume(ConsumeContext<T> context)
	{
		Logger.LogInformation(context.Message.CorrelationId);
		try
		{
			await HandleMessageAsync(context.Message);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, context.Message.CorrelationId);
		}
	}

	public virtual Task HandleMessageAsync(T message)
	{
		return Task.CompletedTask;
	}
}
