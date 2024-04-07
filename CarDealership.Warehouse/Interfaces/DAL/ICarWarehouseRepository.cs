using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.DAL;

public interface ICarWarehouseRepository
{
	Task<CarFile> GetCarByIdAsync(string carId);
	Task<CarInfo> GetCarInfoByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<List<CarInfo>> GetAvailableCarsByFilterAsync(CarFilter carFilter);
	Task<long> GetAvailableCarsCountByFilterAsync(CarFilter carFilter);
	Task<CarFile> CreateCarAsync(CarFile carFile);
	Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit);
	Task<CarFile> EditCarStatusArrivalAsync(string carId, string vIN);
	Task<CarFile> EditCarStatusAsync(string carId, InventoryStatus status);
	Task DeleteCarAsync(string carId);
}