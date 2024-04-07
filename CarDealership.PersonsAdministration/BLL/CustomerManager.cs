using CarDealership.Contracts;
using CarDealership.Contracts.Model.CarDealershipModel.Filter;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer;
using CarDealership.Contracts.Model.CarDealershipModel.Person.Customer.DTO;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Infrastructure;
using CarDealership.PersonsAdministration.Interfaces.BLL;
using CarDealership.PersonsAdministration.Interfaces.DAL;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarDealership.PersonsAdministration.BLL;

public class CustomerManager : ICustomerManager
{
	public IObjectUsageManager ObjectUsageManager { get; }
	public ICustomerRepository CustomerRepository { get; }

	public CustomerManager(IObjectUsageManager objectUsageManager,
		ICustomerRepository customerRepository)
	{
		ObjectUsageManager = objectUsageManager;
		CustomerRepository = customerRepository;
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

		if (customerEdit.IsObjectValid(out string errorMessage))
			throw new InvalidDataException(errorMessage);

		bool isValid = Helper.ValidationInputData(customerEdit, customerId, customerId);

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
		var isUsing = await ObjectUsageManager.IsCustomerIdUsedAsync(customerId);
		if (isUsing)
			new Exception($"{nameof(customerId)}: {customerId} {ConstantApp.DeleteError}");

		await CustomerRepository.DeleteCustomerAsync(customerId);
	}
}
