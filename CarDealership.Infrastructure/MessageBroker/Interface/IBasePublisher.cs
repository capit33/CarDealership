using System.Threading.Tasks;

namespace CarDealership.Infrastructure.MessageBroker.Interface;

public interface IBasePublisher<T>
{
	public Task SendMessage(T message);
}
