using Microsoft.Extensions.DependencyInjection;
using service.CRM.Driven.Adapter.Data.Connections;

namespace service.CRM.Driven.Adapter.Data;

public static class AdapterModuleDependency
{
    public static void AddAdapterModule(this IServiceCollection services)
    {
        services.AddSingleton<IDocumentDbConnection, DocumentDbConnection>();
    }
}