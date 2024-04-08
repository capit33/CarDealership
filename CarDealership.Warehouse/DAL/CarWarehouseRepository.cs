using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using CarDealership.Infrastructure.Repository;
using CarDealership.Warehouse.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.DAL;

public class CarWarehouseRepository : BaseMongoRepository<CarFile>, ICarWarehouseRepository
{
	private readonly SortDefinition<CarFile> _sortDefinitionDefault;

	public CarWarehouseRepository(IConfiguration configuration)
		: base(configuration, "carWarehouse")
	{
		_sortDefinitionDefault = Builders<CarFile>.Sort.Ascending(c => c.Make)
			.Ascending(c => c.Model)
			.Ascending(c => c.ModelTrim)
			.Ascending(c => c.Year);
	}

	public async Task<CarFile> GetCarByIdAsync(string carId)
	{
		return await Collection.Find(c => c.Id == carId).SingleOrDefaultAsync();
	}
	public async Task<CarInfo> GetCarInfoByIdAsync(string carId)
	{
		return await Collection.Find(c => c.Id == carId)
			.Project(CarInfoProjectionDefinition())
			.SingleOrDefaultAsync();
	}

	public async Task<List<CarInfo>> GetAvailableCarsAsync()
	{
		var filter = Builders<CarFile>.Filter.Where(c => c.InventoryStatus == InventoryStatus.Available);
		return await Collection.Find(filter)
			.Sort(_sortDefinitionDefault)
			.Project(CarInfoProjectionDefinition())
			.ToListAsync();
	}

	public async Task<List<CarInfo>> GetCarsByFilterAsync(CarFilter carFilter, InventoryStatus? inventoryStatus = null)
	{
		var filter = FilterDefinition(carFilter, inventoryStatus);
		return await Collection.Find(filter)
			.Sort(_sortDefinitionDefault)
			.Skip(carFilter.PageNumber * carFilter.PageSize)
			.Limit(carFilter.PageSize)
			.Project(CarInfoProjectionDefinition())
			.ToListAsync();
	}

	public async Task<long> GetCarsCountByFilterAsync(CarFilter carFilter, InventoryStatus? inventoryStatus = null)
	{
		var filter = FilterDefinition(carFilter, inventoryStatus);
		return await Collection.CountDocumentsAsync(filter);
	}

	public async Task<CarFile> CreateCarAsync(CarFile carFile)
	{
		carFile.Id = ObjectId.GenerateNewId().ToString();
		await Collection.InsertOneAsync(carFile);
		return await GetCarByIdAsync(carFile.Id);
	}

	public Task<CarFile> EditCarAsync(string carId, CarFileEdit carFileEdit)
	{
		var filter = Builders<CarFile>.Filter.Where(c => c.Id == carId);
		var update = UpdateDefinition(carFileEdit);
		return Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public Task<CarFile> EditCarStatusArrivalAsync(string carId, string vIN)
	{
		var filter = Builders<CarFile>.Filter.Where(c => c.Id == carId);
		var update = Builders<CarFile>.Update.Set(c => c.VIN, vIN)
			.Set(c => c.InventoryStatus, InventoryStatus.Available);

		return Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public Task<CarFile> EditCarStatusAsync(string carId, InventoryStatus status)
	{
		var filter = Builders<CarFile>.Filter.Where(c => c.Id == carId);
		var update = Builders<CarFile>.Update.Set(c => c.InventoryStatus, status);
		return Collection.FindOneAndUpdateAsync(filter, update, _defaultUpdateOptions);
	}

	public async Task DeleteCarAsync(string carId)
	{
		await Collection.DeleteOneAsync(c => c.Id == carId);
	}

	private ProjectionDefinition<CarFile, CarInfo> CarInfoProjectionDefinition()
	{
		//return Builders<CarFile>.Projection.Expression(c => new CarInfo(c.Id, c.InventoryStatus, c));

		return Builders<CarFile>.Projection.Expression(c => new CarInfo()
		{
			CarId = c.Id,
			InventoryStatus = c.InventoryStatus,
			Make = c.Make,
			Model = c.Model,
			ModelTrim = c.ModelTrim,
			Year = c.Year
		});
	}

	private FilterDefinition<CarFile> FilterDefinition(CarFilter carFilter, InventoryStatus? inventoryStatus = null)
	{
		var filters = new List<FilterDefinition<CarFile>>();

		if (inventoryStatus != null)
			filters.Add(Builders<CarFile>.Filter
					.Where(c => c.InventoryStatus == inventoryStatus));

		if (!string.IsNullOrWhiteSpace(carFilter.Make))
			filters.Add(Builders<CarFile>.Filter
					.Where(c => c.Make.ToLowerInvariant().Contains(carFilter.Make.ToLowerInvariant())));

		if (!string.IsNullOrWhiteSpace(carFilter.Model))
			filters.Add(Builders<CarFile>.Filter
					.Where(c => c.Model.ToLowerInvariant().Contains(carFilter.Model.ToLowerInvariant()))); 
		
		if (carFilter.Year != null)
			filters.Add(Builders<CarFile>.Filter
					.Where(c => c.Year == carFilter.Year));

		if (filters.Any())
			return Builders<CarFile>.Filter.And(filters);
		return Builders<CarFile>.Filter.Empty;
	}

	private UpdateDefinition<CarFile> UpdateDefinition(CarFileEdit carFileEdit)
	{
		var updates = new List<UpdateDefinition<CarFile>>();

		if (carFileEdit.Make != null)
			updates.Add(Builders<CarFile>.Update.Set(c => c.Make, carFileEdit.Make));
		if (carFileEdit.Model != null)
			updates.Add(Builders<CarFile>.Update.Set(c => c.Model, carFileEdit.Model));
		if (carFileEdit.ModelTrim != null)
			updates.Add(Builders<CarFile>.Update.Set(c => c.ModelTrim, carFileEdit.ModelTrim));
		if (carFileEdit.Year != null)
			updates.Add(Builders<CarFile>.Update.Set(c => c.Year, carFileEdit.Year));

		return Builders<CarFile>.Update.Combine(updates);
	}
}
