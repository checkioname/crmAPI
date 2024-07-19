using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace service.CRM.Driven.Adapter.Data.Data;

public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase? _database;

    public MongoDbService(IConfiguration configuration)
    {
        _configuration = configuration;
        var connectionString = _configuration.GetConnectionString("DbConnection");
        Console.WriteLine(connectionString);
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName); 
    }

    public IMongoDatabase? Database => _database;
}
    
