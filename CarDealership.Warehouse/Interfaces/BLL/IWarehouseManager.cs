using CarDealership.Contracts.Model.Filters;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface IWarehouseManager
{
	Task<object> GetCarsByFilterAsync(CarFilter carFilter);
	Task<object> GetAvailableCarsAsync();
}