using CarDealership.Contracts.Model.QueueModel;
using CarDealership.Infrastructure.MessageBroker.Interface;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure.MessageBroker;

public class BasePublisher<T, TY> : IBasePublisher<T>
	where T : BaseQueueMessage, new()
{
	private readonly IPublishEndpoint _publishEndpoint;
	public ILogger<TY> Logger { get; }

	public BasePublisher(IPublishEndpoint publishEndpoint,
		ILogger<TY> logger)
	{
		_publishEndpoint = publishEndpoint;
		Logger = logger;
	}

	public async Task SendMessage(T message)
	{
		try
		{
			message.CorrelationId = Guid.NewGuid().ToString();
			await _publishEndpoint.Publish(message);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex, message.CorrelationId);
		}
	}
}
