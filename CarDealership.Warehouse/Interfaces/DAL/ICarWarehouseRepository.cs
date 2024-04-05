using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface ICarWarehouseRepository
{
	Task<CarInfo> GetCarByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<List<CarInfo>> GetAvailableCarsByFilterAsync(CarFilter carFilter);
	Task<long> GetAvailableCarsCountByFilterAsync(CarFilter carFilter);
	Task<CarFile> CreateCarAsync(CarFile carFile);
}