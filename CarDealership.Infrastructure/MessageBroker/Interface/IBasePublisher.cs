using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure.MessageBroker.Interface;

public interface IBasePublisher<T>
{
	public Task SendMessage(T message);
}
