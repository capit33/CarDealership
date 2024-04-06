using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface IChangeOrderStatusManager
{
	Task CarDeleteAsync(string carId);
}