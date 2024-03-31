using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL
{
	public interface ICustomerOrdersManager
	{
		Task<object> GetOpenOrdersAsync();
		Task<object> OrderCompletedAsync(string orderId);
	}
}