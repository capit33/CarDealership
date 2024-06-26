﻿namespace CarDealership.Contracts.Model.WarehouseModel.DTO;

public class WarehouseCustomerOrderInfo
{
	public string CarDealershipOrderId { get; set; }
	public string CustomerFirstName { get; set; }
	public string CustomerLastName { get; set; }
	public string ReservedCarId { get; set; }

	public WarehouseCustomerOrderInfo()
	{
	}

	public WarehouseCustomerOrderInfo(WarehouseCustomerOrder warehouseCustomerOrder)
	{
		CarDealershipOrderId = warehouseCustomerOrder.CarDealershipOrderId;
		CustomerFirstName = warehouseCustomerOrder.CustomerFirstName;
		CustomerLastName = warehouseCustomerOrder.CustomerLastName;
		ReservedCarId = warehouseCustomerOrder.ReservedCarId;
	}
}
