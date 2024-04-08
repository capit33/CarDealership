using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class CarWarehouseRepository : BaseMongoRepository<CarFile>, ICarWarehouseRepository
{
	public CarWarehouseRepository(IConfiguration configuration)
		: base(configuration, "carWarehouse")
	{
	}

	public Task<CarFile> GetCarByIdAsync(string carId)
	{
		throw new System.NotImplementedException();
	}
	public Task<CarInfo> GetCarInfoByIdAsync(string carId)
	{
		throw new System.NotImplementedException();
	}

	public Task<List<CarInfo>> GetAvailableCarsAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task<List<CarInfo>> GetAvailableCarsByFilterAsync(CarFilter carFilter)
	{
		throw new System.NotImplementedException();
	}

	public Task<long> GetAvailableCarsCountByFilterAsync(CarFilter carFilter)
	{
		throw new System.NotImplementedException();
	}

	public Task<CarFile> CreateCarAsync(CarFile carFile)
	{
		throw new System.NotImplementedException();
	}

	public Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit)
	{
		throw new System.NotImplementedException();
	}

	public Task<CarFile> EditCarStatusArrivalAsync(string carId, string vIN)
	{
		throw new System.NotImplementedException();
	}

	public Task<CarFile> EditCarStatusAsync(string carId, InventoryStatus status)
	{
		throw new System.NotImplementedException();
	}

	public Task DeleteCarAsync(string carId)
	{
		throw new System.NotImplementedException();
	}
}
