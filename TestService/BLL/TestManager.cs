using System.Threading.Tasks;
using TestService.Interface;

namespace TestService.BLL;

public class TestManager : ITestManager
{

	private ICarDealershipRestClient CarDealershipRestClient { get; }
	private IPersonsAdministrationRestClient PersonsAdministrationRestClient { get; }
	private IWarehouseRestClient WarehouseRestClient { get; }

	public TestManager(ICarDealershipRestClient carDealershipRestClient, 
		IPersonsAdministrationRestClient personsAdministrationRestClient, 
		IWarehouseRestClient warehouseRestClient)
	{
		CarDealershipRestClient = carDealershipRestClient;
		PersonsAdministrationRestClient = personsAdministrationRestClient;
		WarehouseRestClient = warehouseRestClient;
	}



	#region CarDealershipRestClient

	public async Task CarDealershipCustomerOrderAsync()
	{
	}

	public Task CarDealershipSearchAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task CarDealershipWarehouseAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task CarDealershipWarehouseOrderAsync()
	{
		throw new System.NotImplementedException();
	}

	#endregion

	#region PersonsAdministrationRestClient

	public Task PersonCustomerAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task PersonEmployeeAsync()
	{
		throw new System.NotImplementedException();
	}

	#endregion

	#region WarehouseRestClient

	public Task WarehouseCarWarehouseAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task WarehouseClientAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task WarehouseCustomerOrderAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task WarehousePurchaseOrderAsync()
	{
		throw new System.NotImplementedException();
	}

	public Task WarehouseSupplierOrderAsync()
	{
		throw new System.NotImplementedException();
	}

	#endregion
}
