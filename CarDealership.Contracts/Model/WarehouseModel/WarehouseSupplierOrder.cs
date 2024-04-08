using CarDealership.Contracts.Enum;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace CarDealership.Contracts.Model.WarehouseModel;

public class WarehouseSupplierOrder
{
	public string Id { get; set; }
	public string SupplierName { get; set; }
	public string CarFileId { get; set; }
	[BsonRepresentation(BsonType.String)]
	public DocumentStatus DocumentStatus { get; set; }
	public DateTime CreatedDate { get; set; }
}
