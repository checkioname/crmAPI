using MongoDB.Driver;
using service.CRM.Driven.Adapter.Data.Config;
using service.CRM.Driven.Adapter.Data.Data.Secrets;

namespace service.CRM.Driven.Adapter.Data.Connections;

public interface IDocumentDbConnection
{
    IMongoDatabase GetDefaultDatabase();

    IMongoClient Client(DocumentDbConfiguration documentDbConfiguration, DocumentDbSecret documentDbSecret);
}