using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.CarModel.Interface;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class CarWarehouseManager : ICarWarehouseManager
{
	private IChangeOrderStatusManager ChangeOrderStatusManager { get; }
	private ICarWarehouseRepository CarWarehouseRepository { get; }

	public CarWarehouseManager(ICarWarehouseRepository carWarehouseRepository,
		IChangeOrderStatusManager changeOrderStatusManager)
	{
		ChangeOrderStatusManager = changeOrderStatusManager;
		CarWarehouseRepository = carWarehouseRepository;
	}

	public async Task<List<CarInfo>> GetAvailableCarsAsync()
	{
		return await CarWarehouseRepository.GetAvailableCarsAsync();
	}

	public async Task<CarFile> GetCarByIdAsync(string carId)
	{
		if (string.IsNullOrWhiteSpace(carId))
			throw new ArgumentNullException(nameof(carId));

		return await CarWarehouseRepository.GetCarByIdAsync(carId);
	}

	public async Task<CarInfo> GetCarInfoByIdAsync(string carId)
	{
		if (string.IsNullOrWhiteSpace(carId))
			throw new ArgumentNullException(nameof(carId));

		return await CarWarehouseRepository.GetCarInfoByIdAsync(carId);
	}

	public async Task<PageItems<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter, string inventoryStatus = null)
	{
		if (carFilter == null)
			throw new ArgumentNullException(nameof(carFilter));

		if (!carFilter.IsPaginationValid(out string message))
			throw new InvalidDataException(message);

		InventoryStatus? inventoryStatusEnum = null;

		if (inventoryStatus != null)
		{
			InventoryStatus tempStatus;
			if (!Enum.TryParse(inventoryStatus, true, out tempStatus))
				throw new ArgumentException(ConstantApp.DocumentStatusNotValidError);
			inventoryStatusEnum = tempStatus;
		}

		var pageItems = new PageItems<CarInfo>(carFilter);

		var carCount = await CarWarehouseRepository.GetCarsCountByFilterAsync(carFilter, inventoryStatusEnum);

		if (carCount == 0)
			return pageItems;

		pageItems.SetPageCount((int)carCount);
		pageItems.Items = await CarWarehouseRepository.GetCarsByFilterAsync(carFilter, inventoryStatusEnum);

		return pageItems;
	}

	public async Task<CarFile> CreateCarAsync(ICar carFileCreate)
	{
		var carFile = CreateCarValidationData(carFileCreate, InventoryStatus.Created);
		return await CarWarehouseRepository.CreateCarAsync(carFile);
	}

	public async Task<CarFile> CreateCarByOrderAsync(ICar carFileCreate)
	{
		var carFile = CreateCarValidationData(carFileCreate, InventoryStatus.Ordered);
		return await CarWarehouseRepository.CreateCarAsync(carFile);
	}

	public async Task<CarFile> CarArrivalAsync(string carId, string VIN)
	{
		if (string.IsNullOrWhiteSpace(VIN))
			throw new ArgumentNullException(nameof(VIN));

		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(carFile), carId));

		if (!(carFile.InventoryStatus == InventoryStatus.Created
			|| carFile.InventoryStatus == InventoryStatus.Ordered))
			throw new InvalidOperationException(ConstantApp.CarStatusNotValidError);

		return await CarWarehouseRepository.EditCarStatusArrivalAsync(carId, VIN);
	}

	public async Task<CarFile> CarSoldOutAsync(string carId)
	{
		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			return null;

		if (!(carFile.InventoryStatus == InventoryStatus.Available
			|| carFile.InventoryStatus == InventoryStatus.Reserved))
			throw new InvalidOperationException(ConstantApp.CarNotAvailableError);

		return await CarWarehouseRepository.EditCarStatusAsync(carId, InventoryStatus.SoldOut);
	}

	public async Task<CarFile> CarReservationAsync(string carId)
	{
		Helper.InputIdValidation(carId);

		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(carFile), carId));

		if (carFile.InventoryStatus != InventoryStatus.Available)
			throw new InvalidOperationException(ConstantApp.CarNotAvailableError);

		return await CarWarehouseRepository.EditCarStatusAsync(carId, InventoryStatus.Reserved);
	}

	public async Task<CarFile> CanceledCarReservationAsync(string carId)
	{
		Helper.InputIdValidation(carId);

		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(carFile), carId));

		if (carFile.InventoryStatus != InventoryStatus.Reserved)
			throw new InvalidOperationException(ConstantApp.CarNotReservationError);

		return await CarWarehouseRepository.EditCarStatusAsync(carId, InventoryStatus.Available);
	}

	public async Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit)
	{
		Helper.InputIdValidation(carId);
		Helper.InputDataValidation(carFileEdit);

		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			throw new InvalidDataException(ConstantApp.GetNotFoundErrorMessage(nameof(carFile), carId));

		if (carFile.InventoryStatus == InventoryStatus.SoldOut
			|| carFile.InventoryStatus == InventoryStatus.Reserved)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageEditNotPossible(nameof(carFile.InventoryStatus), carFile.InventoryStatus.ToString()));

		return await CarWarehouseRepository.EditCarAsync(carId, carFileEdit);
	}

	public async Task DeleteCarAsync(string carId)
	{
		Helper.InputIdValidation(carId);
		var carFile = await GetCarByIdAsync(carId);

		if (carFile == null)
			return;

		if (carFile.InventoryStatus == InventoryStatus.SoldOut)
			throw new InvalidOperationException(
					ConstantApp.GetErrorMessageDeleteNotPossible(nameof(carFile.InventoryStatus), carFile.InventoryStatus.ToString()));

		if (carFile.InventoryStatus == InventoryStatus.Reserved)
			await ChangeOrderStatusManager.CarDeleteAsync(carFile.Id);

		await CarWarehouseRepository.DeleteCarAsync(carId);
	}

	private CarFile CreateCarValidationData(ICar car, InventoryStatus status)
	{
		if (car == null)
			throw new ArgumentNullException(nameof(car));

		if (!car.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		return new CarFile(car, status);
	}
}
