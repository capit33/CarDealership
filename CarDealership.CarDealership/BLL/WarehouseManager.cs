using CarDealership.CarDealership.Interfaces.BLL;
using CarDealership.CarDealership.Interfaces.RestClients;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.BLL;

public class WarehouseManager : IWarehouseManager
{
	private IWarehouseRestClient WarehouseRestClient { get; }

	public WarehouseManager(IWarehouseRestClient warehouseRestClient)
	{
		WarehouseRestClient = warehouseRestClient;
	}

	public async Task<CarInfo> GetCarWarehouseByIdAsync(string carId)
	{
		Helper.InputIdValidation(carId);

		return await WarehouseRestClient.GetCarWarehouseByIdAsync(carId);
	}

	public async Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter)
	{
		if (carFilter == null)
			throw new ArgumentNullException(nameof(carFilter));

		var isValid = carFilter.IsPaginationValid(out string message);

		if (!isValid)
			throw new InvalidDataException(message);

		return await WarehouseRestClient.GetCarsWarehouseByFilterAsync(carFilter);
	}
}
