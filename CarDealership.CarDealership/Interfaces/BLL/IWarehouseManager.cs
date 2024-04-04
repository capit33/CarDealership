using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.BLL
{
	public interface IWarehouseManager
	{
		Task<CarInfo> GetCarInWarehouseByIdAsync(string carId);
		Task<List<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter);
	}
}