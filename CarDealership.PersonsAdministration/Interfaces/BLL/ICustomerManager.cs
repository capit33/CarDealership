﻿using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.Person.Customer;
using CarDealership.Contracts.Model.Person.Customer.DTO;
using System.Threading.Tasks;

namespace CarDealership.PersonsAdministration.Interfaces.BLL;

public interface ICustomerManager
{
	Task<Customer> GetCustomerByIdAsync(string customerId);
	Task<PageItems<Customer>> GetCustomerByFilterAsync(CustomerFilter customerFilter);
	Task<Customer> CreateCustomerAsync(Customer customer);
	Task<Customer> EditCustomerAsync(string customerId, CustomerEdit customerEdit);
	Task<Customer> RestoreCustomerAsync(string customerId);
	Task RemoveCustomerAsync(string customerId);
	Task DeleteCustomerAsync(string customerId);
}