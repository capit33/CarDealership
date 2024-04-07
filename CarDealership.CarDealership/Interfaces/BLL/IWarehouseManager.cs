using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL
{
	public interface IWarehouseManager
	{
		Task<CarInfo> GetCarWarehouseByIdAsync(string carId);
		Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter);
	}
}