using CarDealership.Contracts.Enum;
using CarDealership.Contracts.Model.CarModel;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace CarDealership.Contracts.Model.CarDealershipModel.Orders;

public class CustomerOrder
{
	public string Id { get; set; }
	public string CustomerId { get; set; }
	public string EmployeeId { get; set; }
	public string ReservedCarId { get; set; }
	public Car Car { get; set; }
	[BsonRepresentation(BsonType.String)]
	public DocumentStatus DocumentStatus { get; set; }
	public DateTime CreatedDate { get; set; }
}
