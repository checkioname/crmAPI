using Microsoft.Extensions.Options;
using MongoDB.Driver;
using service.CRM.Driven.Adapter.Data.Config;

namespace service.CRM.Driven.Adapter.Data.Connections;

public class DocumentDbConnection : IDocumentDbConnection
{
    private readonly DocumentDbConfiguration _documentDbConfiguration;
    public DocumentDbConnection(IOptions<DocumentDbConfiguration> documentDbConf)
    {
        ArgumentNullException.ThrowIfNull(documentDbConf);
        ArgumentNullException.ThrowIfNull(documentDbConf.Value.ConnectionString);
        
        _documentDbConfiguration = documentDbConf.Value;
    }

    public IMongoClient Client(DocumentDbConfiguration documentDbConf)
    {
        Console.WriteLine("Inicio da conexao com banco de dados");

        Console.WriteLine(
        $" ConnectionString do Banco - {documentDbConf.ConnectionString} "
        );

        var settings = MongoClientSettings.FromUrl(new MongoUrl(documentDbConf.ConnectionString));
        return new MongoClient(settings);
    }

    public IMongoDatabase GetDefaultDatabase() => 
        Client(_documentDbConfiguration).GetDatabase(_documentDbConfiguration.DefaultDatabase);
}