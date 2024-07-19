using Microsoft.Extensions.Options;
using service.CRM.Driven.Adapter.Data;
using service.CRM.Driven.Adapter.Data.Config;
using service.CRM.Driven.Adapter.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurações padrão do aplicativo
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoDbService>();

//Database dependencies
builder.Services.AddAdapterModule();

// Obter a seção de configuração do banco de dados
var databaseConfigSection = builder.Configuration.GetSection("Database");

// Configurar DocumentDbConfiguration usando IOptions
builder.Services.Configure<DocumentDbConfiguration>(databaseConfigSection);

// Configurar serviço Singleton com base nas configurações do DocumentDbConfiguration
builder.Services.AddSingleton(provider =>
    provider.GetRequiredService<IOptions<DocumentDbConfiguration>>().Value
);
//Console.WriteLine($"VALOR DAS CONFIGURAÇÕES DO BANCO: {provider.GetRequiredService<IOptions<DocumentDbConfiguration>>().Value}");

// Construir o aplicativo
var app = builder.Build();

// Obter as configurações do banco de dados
//var databaseSettings = app.Services.GetRequiredService<DocumentDbConfiguration>();


// Configurações do Swagger (exemplo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar pipeline HTTP
app.UseHttpsRedirection();
app.MapControllers();

// Iniciar o aplicativo
app.Run();