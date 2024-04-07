using CarDealership.Contracts.Model.CarModel;
using CarDealership.Contracts.Model.Filters;
using CarDealership.Contracts.Model.WarehouseModel.DTO;
using CarDealership.Contracts.Model.WarehouseModel.Filter;
using System.Threading.Tasks;

namespace CarDealership.CarDealership.Interfaces.RestClients;

public interface IWarehouseRestClient
{
	Task CanceledWarehouseOrderAsync(string warehouseOrderId);
	Task<WarehouseCustomerOrderInfo> CreateCustomerOrderAsync(WarehouseCarDealershipCustomerOrderCreate carDealershipCustomerOrderCreate);
	Task<WarehouseCustomerOrderInfo> EditCustomerOrderAsync(string customerOrderId, WarehouseCustomerOrderEdit warehouseCustomerOrderEdit);
	Task<PageItems<CarInfo>> GetCarsWarehouseByFilterAsync(CarFilter carFilter);
	Task<CarInfo> GetCarWarehouseByIdAsync(string carId);
}