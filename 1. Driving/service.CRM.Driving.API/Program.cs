using Microsoft.OpenApi.Models;
using service.CRM.Driven.Adapter.Data;
using service.CRM.Driven.Adapter.Data.Collections;
using service.CRM.Driven.Adapter.Data.Config;
using service.CRM.Driven.Adapter.Data.Connections;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    Console.WriteLine($"AMBIENTE: {hostingContext.HostingEnvironment.EnvironmentName}");
    //config.AddConfigServer(hostingContext.HostingEnvironment);
});


var databaseConfigSection = builder.Configuration.GetSection("Database");
Console.WriteLine("VALOR DA CONFIG SECTION - MONGO", databaseConfigSection);

builder.Services.Configure<DocumentDbConfiguration>(databaseConfigSection);

builder.Services.AddAdapterModule();
builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IDocumentDbConnection, DocumentDbConnection>();

var documentDbSecretName = databaseConfigSection.Get<DocumentDbConfiguration>().ConnectionString;






// Adiciona serviços ao contêiner.
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSingleton<MongoDbService>();


// Configura o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Minha API", 
        Version = "v1",
        Description = "Uma simples API de exemplo com .NET 8 e Swagger"
    });

    // Configurações adicionais do Swagger podem ser adicionadas aqui
});

var app = builder.Build();



// Configura o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty; // Serve o Swagger na raiz do aplicativo
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();