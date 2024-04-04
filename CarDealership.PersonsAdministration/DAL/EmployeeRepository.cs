using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Employee.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Infrastructure.Repository;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.DAL;

public class EmployeeRepository : BaseMongoRepository<Employee>, IEmployeeRepository
{
	public EmployeeRepository(IConfiguration configuration) : base(configuration, "employees")
	{
	}


	public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
	{
		return await Collection.Find(e => e.Id == employeeId).SingleOrDefaultAsync();
	}

	public async Task<List<Employee>> GetEmployeesByFilterAsync(EmployeeFilter employeeFilter)
	{
		var filter = FilterDefinition(employeeFilter);
		var sort = Builders<Employee>.Sort.Ascending(e => e.LastName).Ascending(e => e.FirstName);

		return await Collection.Find(filter)
			.Sort(sort)
			.Skip(employeeFilter.PageNumber * employeeFilter.PageSize)
			.Limit(employeeFilter.PageSize)
			.ToListAsync();
	}

	public async Task<long> GetEmployeeCountByFilterAsync(EmployeeFilter employeeFilter)
	{
		var filter = FilterDefinition(employeeFilter);
		return await Collection.CountDocumentsAsync(filter);
	}

	public async Task<Employee> CreateEmployeeAsync(Employee employee)
	{
		employee.Id = ObjectId.GenerateNewId().ToString();
		await Collection.InsertOneAsync(employee);
		return await GetEmployeeByIdAsync(employee.Id);
	}

	public async Task<Employee> EditEmployeeAsync(string employeeId, EmployeeEdit employeeEdit)
	{
		var filter = Builders<Employee>.Filter.Where(e => e.Id == employeeId);
		var update = UpdateDefinition(employeeEdit);
		var options = new FindOneAndUpdateOptions<Employee, Employee>()
		{
			ReturnDocument = ReturnDocument.After
		};
		
		return await Collection.FindOneAndUpdateAsync(filter, update, options);
	}

	public async Task<Employee> ChangeEmployeeRemoveStatusAsync(string employeeId, bool removeStatus)
	{
		var filter = Builders<Employee>.Filter.Where(e => e.Id == employeeId);
		var update = Builders<Employee>.Update.Set(e => e.IsRemove, removeStatus);
		var options = new FindOneAndUpdateOptions<Employee, Employee>()
		{
			ReturnDocument = ReturnDocument.After
		};

		return await Collection.FindOneAndUpdateAsync(filter, update, options);
	}

	public async Task DeleteEmployeeAsync(string employeeId)
	{
		await Collection.DeleteOneAsync(e => e.Id == employeeId);
	}

	private FilterDefinition<Employee> FilterDefinition(EmployeeFilter employeeFilter)
	{
		var filters = new List<FilterDefinition<Employee>>();

		if (!string.IsNullOrWhiteSpace(employeeFilter.FirstName))
			filters.Add(Builders<Employee>.Filter
					.Where(e => e.FirstName.ToLowerInvariant().Contains(employeeFilter.FirstName.ToLowerInvariant())));

		if (!string.IsNullOrWhiteSpace(employeeFilter.LastName))
			filters.Add(Builders<Employee>.Filter
					.Where(e => e.LastName.ToLowerInvariant().Contains(employeeFilter.LastName.ToLowerInvariant())));

		if (!string.IsNullOrWhiteSpace(employeeFilter.Position))
			filters.Add(Builders<Employee>.Filter
					.Where(e => e.Position.ToLowerInvariant().Contains(employeeFilter.Position.ToLowerInvariant())));

		if (employeeFilter.IsRemove != null)
			filters.Add(Builders<Employee>.Filter
					.Where(e => e.IsRemove == employeeFilter.IsRemove));

		if (filters.Any()) 
			return Builders<Employee>.Filter.And(filters);
		return Builders<Employee>.Filter.Empty;
	}

	private UpdateDefinition<Employee> UpdateDefinition(EmployeeEdit employeeEdit)
	{
		var updates = new List<UpdateDefinition<Employee>>();

		if (employeeEdit.FirstName != null)
			updates.Add(Builders<Employee>.Update.Set(e => e.FirstName, employeeEdit.FirstName));
		if (employeeEdit.LastName != null)
			updates.Add(Builders<Employee>.Update.Set(e => e.LastName, employeeEdit.LastName));
		if (employeeEdit.Position!= null)
			updates.Add(Builders<Employee>.Update.Set(e => e.Position, employeeEdit.Position));

		return Builders<Employee>.Update.Combine(updates);
	}
}
