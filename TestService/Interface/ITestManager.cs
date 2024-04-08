using System.Threading.Tasks;

namespace TestService.Interface;

public interface ITestManager
{
	Task CarDealershipCustomerOrderAsync();
	Task CarDealershipSearchAsync();
	Task CarDealershipWarehouseAsync();
	Task CarDealershipWarehouseOrderAsync();
	Task PersonCustomerAsync();
	Task PersonEmployeeAsync();
	Task WarehouseCarWarehouseAsync();
	Task WarehouseClientAsync();
	Task WarehouseCustomerOrderAsync();
	Task WarehousePurchaseOrderAsync();
	Task WarehouseSupplierOrderAsync();
}