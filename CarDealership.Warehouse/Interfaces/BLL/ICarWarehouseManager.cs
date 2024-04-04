using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICarWarehouseManager
{
	Task<CarInfo> GetCarByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<List<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter);
	Task<CarFile> CreateCarAsync(CarFile carFile);
	Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit);
	Task DeleteCarAsync(string carId);
}