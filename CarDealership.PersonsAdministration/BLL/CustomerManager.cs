using CarDealership.Contracts;
using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Contracts.Model.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Infrastructure;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using CarDealership.PersonsAdministration.Interfaces.RestClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.BLL;

public class CustomerManager : ICustomerManager
{
	public ICustomerRepository CustomerRepository { get; }
	public ICarDealershipRestClient CarDealershipRestClient { get; }

	public CustomerManager(ICustomerRepository customerRepository,
		ICarDealershipRestClient carDealershipRestClient)
	{
		CustomerRepository = customerRepository;
		CarDealershipRestClient = carDealershipRestClient;
	}

	public async Task<Customer> GetCustomerByIdAsync(string customerId)
	{
		if (string.IsNullOrWhiteSpace(customerId))
			throw new ArgumentNullException(nameof(customerId));

		return await CustomerRepository.GetCustomerByIdAsync(customerId);
	}

	public async Task<PageItems<Customer>> GetCustomerByFilterAsync(CustomerFilter customerFilter)
	{
		if (customerFilter == null)
			throw new ArgumentNullException(nameof(customerFilter));

		var isValid = customerFilter.IsPaginationValid(out string message);
		if (!isValid)
			throw new InvalidDataException(message);

		var pageItems = new PageItems<Customer>(customerFilter);

		var customerCount = await CustomerRepository.GetCustomerCountByFilterAsync(customerFilter);

		if (customerCount == 0)
			return pageItems;

		pageItems.SetPageCount((int)customerCount);
		pageItems.Items = await CustomerRepository.GetCustomersByFilterAsync(customerFilter);

		return pageItems;
	}

	public async Task<Customer> CreateCustomerAsync(Customer customer)
	{
		if (customer == null)
			throw new ArgumentNullException(nameof(customer));

		if (!customer.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		return await CustomerRepository.CreateCustomerAsync(customer);
	}

	public async Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit)
	{
		if (string.IsNullOrWhiteSpace(customerId))
			throw new ArgumentNullException(nameof(customerId));

		if (!customerEdit.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		Helper.InputDataValidation(customerEdit);

		return await CustomerRepository.EditCustomerAsync(customerId, customerEdit);
	}

	public async Task<Customer> RestoreCustomerAsync(string customerId)
	{
		if (string.IsNullOrWhiteSpace(customerId))
			throw new ArgumentNullException(nameof(customerId));

		return await CustomerRepository.ChangeCustomerRemoveStatusAsync(customerId, false);
	}

	public async Task RemoveCustomerAsync(string customerId)
	{
		if (string.IsNullOrWhiteSpace(customerId))
			throw new ArgumentNullException(nameof(customerId));

		await CustomerRepository.ChangeCustomerRemoveStatusAsync(customerId, true);
	}

	public async Task DeleteCustomerAsync(string customerId)
	{
		SearchResult result = await CarDealershipRestClient.FindCustomerIdAsync(customerId);
		if (result.Result == SearchResultEnum.Found)
			new Exception($"{nameof(customerId)}: {customerId} {ConstantApp.DeleteError}");

		await CustomerRepository.DeleteCustomerAsync(customerId);
	}
}
