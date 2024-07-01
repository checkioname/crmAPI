using Microsoft.Extensions.Options;
using MongoDB.Driver;
using service.CRM.Driven.Adapter.Data.Config;
using service.CRM.Driven.Adapter.Data.Data.Secrets;

namespace service.CRM.Driven.Adapter.Data.Connections;

public class DocumentDbConnection : IDocumentDbConnection
{
    private readonly DocumentDbConfiguration _documentDbConfiguration;
    private readonly DocumentDbSecret _documentDbSecret;

    public DocumentDbConnection(IOptions<DocumentDbConfiguration> documentDbConf, IOptions<DocumentDbSecret> documentDbSecret)
    {
        ArgumentNullException.ThrowIfNull(documentDbConf);
        ArgumentNullException.ThrowIfNull(documentDbConf.Value.Cluster);
        ArgumentNullException.ThrowIfNull(documentDbConf.Value.DefaultDatabase);
        ArgumentNullException.ThrowIfNull(documentDbConf.Value.Parameters);
        ArgumentNullException.ThrowIfNull(documentDbSecret.Value.Username);
        ArgumentNullException.ThrowIfNull(documentDbSecret.Value.Password);
    }

    public IMongoClient Client(DocumentDbConfiguration documentDbConf, DocumentDbSecret documentDbSecret)
    {
        Console.WriteLine("Inicio da conexao com banco de dados");
        var connectionString = $"mongodb://{documentDbSecret.Username}:{documentDbSecret.Password}@{documentDbConf.Cluster}/{documentDbConf.DefaultDatabase}?{documentDbConf.Parameters}";
        var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        return new MongoClient(settings);
    }

    public IMongoDatabase GetDefaultDatabase() => Client(_documentDbConfiguration, _documentDbSecret)
        .GetDatabase(_documentDbConfiguration.DefaultDatabase);


}