﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure.Repository;

public class BaseMongoRepository<T>
{
	protected IMongoCollection<T> Collection { get; }

	public BaseMongoRepository(IConfiguration configuration, string collectionName)
	{
		var connectionString = configuration["MongoDBConnectionString"];
		var mongoUrl = new MongoUrl(connectionString);
		var settings = MongoClientSettings.FromConnectionString(connectionString);

		var client = new MongoClient(settings);
		Collection = client.GetDatabase(mongoUrl.DatabaseName).GetCollection<T>(collectionName);
	}
}