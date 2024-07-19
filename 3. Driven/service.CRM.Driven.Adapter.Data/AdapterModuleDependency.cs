using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using service.CRM.Driven.Adapter.Data.Collections;
using service.CRM.Driven.Adapter.Data.Connections;

namespace service.CRM.Driven.Adapter.Data;

public static class AdapterModuleDependency
{
    public static IServiceCollection AddAdapterModule(this IServiceCollection services)
    {
        services.AddSingleton<IDocumentDbConnection, DocumentDbConnection>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}