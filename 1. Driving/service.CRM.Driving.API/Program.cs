using service.CRM.Driven.Adapter.Data.Config;
using service.CRM.Driven.Adapter.Data.Data;

var builder = WebApplication.CreateBuilder(args);

var documentDBSection = builder.Configuration.GetSection("Database:DocumentDb");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDbService>();


builder.Services.Configure<DocumentDbConfiguration>(documentDBSection);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();