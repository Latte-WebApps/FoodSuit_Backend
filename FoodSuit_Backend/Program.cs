using FoodSuit_Backend.Dishes.Application.Internal.CommandServices;
using FoodSuit_Backend.Dishes.Application.Internal.QueryServices;
using FoodSuit_Backend.Dishes.Domain.Repositories;
using FoodSuit_Backend.Dishes.Domain.Services;
using FoodSuit_Backend.Dishes.Infrastructure.Persistence.EFC.Repositories;

using FoodSuit_Backend.Orders.Application.Internal.CommandServices;
using FoodSuit_Backend.Orders.Application.Internal.QueryServices;
using FoodSuit_Backend.Orders.Domain.Repositories;
using FoodSuit_Backend.Orders.Domain.Services;
using FoodSuit_Backend.Orders.Infrastructure.Persistence.EFC.Repositories;

using FoodSuit_Backend.Employees.Application.Internal.CommandServices;
using FoodSuit_Backend.Employees.Application.Internal.QueryServices;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Employees.Infrastructure.Persistence.EFC.Repositories;
using FoodSuit_Backend.Inventory.Application.Internal.CommandServices;
using FoodSuit_Backend.Inventory.Application.Internal.QueryServices;
using FoodSuit_Backend.Inventory.Domain.exceptions;
using FoodSuit_Backend.Inventory.Domain.Repositories;
using FoodSuit_Backend.Inventory.Domain.Services;
using FoodSuit_Backend.Inventory.Infrastructure.Persistence.EFC.Repositories;

using FoodSuit_Backend.Finance.Application.Internal.CommandServices;
using FoodSuit_Backend.Finance.Application.Internal.QueryServices;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Finance.Domain.Services;
using FoodSuit_Backend.Finance.Infrastructure.Persistence.EFC.Repositories;
using FoodSuit_Backend.Shared.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;


var builder = WebApplication.CreateBuilder(args);

// Configuración de restricciones de tipo en rutas
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("id", typeof(IntRouteConstraint)); // Solo agrega esta línea, sin duplicar "int"
});

// Apply Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());


// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection string is not set.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});

// Configure Dependency Injection

// Shared Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Dishes Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishCommandService, DishCommandService>();
builder.Services.AddScoped<IDishQueryService, DishQueryService>();

// Orders Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

// Finance Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();

// Inventory Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

//Employees Bounded Context Dependency Injection Configuration

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeCommandService, EmployeeCommandService>();
builder.Services.AddScoped<IEmployeeQueryService, EmployeeQueryService>();

var app = builder.Build();

// Verify Database Objects are Created

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();