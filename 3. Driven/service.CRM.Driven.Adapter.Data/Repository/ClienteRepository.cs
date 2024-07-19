using MongoDB.Driver;
using service.CRM.Core.Domain.Entities;
using service.CRM.Driven.Adapter.Data.Connections;

namespace service.CRM.Driven.Adapter.Data.Collections;

public class ClienteRepository : IClienteRepository
{
    private readonly IDocumentDbConnection _documentDbConnection;

    public ClienteRepository(IDocumentDbConnection documentDbConnection)
    {
        _documentDbConnection = documentDbConnection;
    }

    public async Task<IEnumerable<Cliente>> FindAll()
    {
        IEnumerable<Cliente> clientes =  RecuperarCollection().Find(_ => true).ToList();
        return clientes;
    }

    private IMongoCollection<Cliente> RecuperarCollection() => _documentDbConnection
        .GetDefaultDatabase()
        .GetCollection<Cliente>("Clientes");
}

