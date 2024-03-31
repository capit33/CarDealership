using CarDealership.Contracts.Model.Warehouse.DTO;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface ISupplierOrderManager
{
	Task<object> GetOpenOrdersAsync();
	Task<object> OrderCompletedAsync(string orderId, VINumber number);
}