using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.WarehouseModel;
using CarDealership.Warehouse.Interfaces.BLL;
using CarDealership.Warehouse.Interfaces.DAL;
using CarDealership.Warehouse.MessageBroker.Interface;
using System.Threading.Tasks;

namespace CarDealership.Warehouse.BLL;

public class ChangeOrderStatusManager : IChangeOrderStatusManager
{
	private IPurchaseOrderRepository PurchaseOrderRepository { get; }
	private ICustomerOrderRepository CustomerOrderRepository { get; }
	private IPurchaseOrderStatusQueuePublisher PurchaseOrderStatusQueuePublisher { get;}
	private ICustomerOrderStatusQueuePublisher CustomerOrderStatusQueuePublisher { get; }

	public ChangeOrderStatusManager(IPurchaseOrderRepository purchaseOrderRepository,
		ICustomerOrderRepository customerOrderRepository,
		IPurchaseOrderStatusQueuePublisher purchaseOrderStatusQueuePublisher,
		ICustomerOrderStatusQueuePublisher customerOrderStatusQueuePublisher)
	{
		PurchaseOrderRepository = purchaseOrderRepository;
		CustomerOrderRepository = customerOrderRepository;
		PurchaseOrderStatusQueuePublisher = purchaseOrderStatusQueuePublisher;
		CustomerOrderStatusQueuePublisher = customerOrderStatusQueuePublisher;
	}

	public async Task CarDeleteAsync(string carId)
	{
		var customerOrder = await CustomerOrderRepository.GetCustomerOrderByCarIdAsync()
	}

	public Task CustomerOrderStatusChangeAsync(WarehouseCustomerOrder customerOrder, DocumentStatus processing)
	{
		throw new System.NotImplementedException();
	}

	public Task SupplierOrderStatusChanged(string supplierOrderId, DocumentStatus processing)
	{
		throw new System.NotImplementedException();
	}
}
