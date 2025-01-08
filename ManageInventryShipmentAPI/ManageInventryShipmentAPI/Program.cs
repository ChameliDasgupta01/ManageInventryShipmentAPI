using Microsoft.EntityFrameworkCore;
using ManageInventryShipmentAPI.Data;
using ManageInventryShipmentAPI.DAL;
using ManageInventryShipmentAPI.BAL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services- This refers to the collection of services in the dependency injection container 
// AddDbContext<AppDbContext>():This method is part of the Entity Framework Core library.It registers the AppDbContext class with the dependency injection container. 
// options.UseSqlServer():This configures the database provider for AppDbContext to use SQL Server as the database engine.
// UseSqlServer is a method provided by Entity Framework Core to specify the database type
// This fetches the connection string for the database from the configuration.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Set up Serilog to log to a file
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()         // Logs to Console
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)  // Logs to a file, daily log files
    .CreateLogger();

// Add Serilog to the logging pipeline
builder.Host.UseSerilog();

builder.Services.AddScoped<IProductRepository, ProductRepository>(); // Dependency injection for repository
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
