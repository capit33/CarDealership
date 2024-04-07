using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.Interfaces.BLL;

public interface IChangeOrderStatusManager
{
	Task CarDeleteAsync(string carId);
	Task CustomerOrderStatusChangeAsync(WarehouseCustomerOrder customerOrder, DocumentStatus processing);
	Task SupplierOrderStatusChanged(string supplierOrderId, DocumentStatus processing);
}