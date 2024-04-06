using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.CarModel.Interface;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICarWarehouseManager
{
	Task<CarFile> GetCarByIdAsync(string carId);
	Task<CarInfo> GetCarInfoByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter);
	Task<CarFile> CreateCarAsync(ICar carFileCreate);
	Task<CarFile> CreateCarByOrderAsync(ICar carFileCreate);
	Task<CarFile> CarArrivalAsync(string carId, string VIN);
	Task<CarFile> CarSoldOutAsync(string carId);
	Task<CarFile> CarReservationAsync(string carId);
	Task<CarFile> CanceledCarReservationAsync(string carId);
	Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit);
	Task DeleteCarAsync(string carId);
}