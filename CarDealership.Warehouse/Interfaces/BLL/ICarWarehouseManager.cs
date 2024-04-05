using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ICarWarehouseManager
{
	Task<CarInfo> GetCarByIdAsync(string carId);
	Task<List<CarInfo>> GetAvailableCarsAsync();
	Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter);
	Task<CarFile> CreateCarAsync(CarFileCreate carFileCreate);
	Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit);
	Task DeleteCarAsync(string carId);
}