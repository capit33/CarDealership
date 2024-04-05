using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class CarWarehouseManager : ICarWarehouseManager
{
	private ICarWarehouseRepository CarWarehouseRepository { get; }

	public CarWarehouseManager(ICarWarehouseRepository carWarehouseRepository)
	{
		CarWarehouseRepository = carWarehouseRepository;
	}

	public async Task<List<CarInfo>> GetAvailableCarsAsync()
	{
		return await CarWarehouseRepository.GetAvailableCarsAsync();
	}

	public async Task<CarInfo> GetCarByIdAsync(string carId)
	{
		if (string.IsNullOrWhiteSpace(carId))
			throw new ArgumentNullException(nameof(carId));

		return await CarWarehouseRepository.GetCarByIdAsync(carId);
	}

	public async Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter)
	{
		if (carFilter == null)
			throw new ArgumentNullException(nameof(carFilter));

		var isValid = carFilter.IsPaginationValid(out string message);
		if (!isValid)
			throw new InvalidDataException(message);

		var pageItems = new PageItems<CarInfo>(carFilter);

		var carCount = await CarWarehouseRepository.GetAvailableCarsCountByFilterAsync(carFilter);
		if (carCount == 0)
			return pageItems;

		pageItems.SetPageCount((int)carCount);
		pageItems.Items = await CarWarehouseRepository.GetAvailableCarsByFilterAsync(carFilter);

		return pageItems;
	}
	public async Task<CarFile> CreateCarAsync(CarFileCreate carFileCreate)
	{
		if (carFileCreate == null)
			throw new ArgumentNullException(nameof(carFileCreate));

		if (!carFileCreate.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		var carFile = new CarFile(carFileCreate, Contracts.Enum.InventoryStatus.Created);

		return await CarWarehouseRepository.CreateCarAsync(carFile);
	}

	public Task DeleteCarAsync(string carId)
	{
		throw new System.NotImplementedException();
	}

	public Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit)
	{
		throw new System.NotImplementedException();
	}
}
