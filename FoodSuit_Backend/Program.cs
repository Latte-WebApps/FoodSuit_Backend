using FoodSuit_Backend.Finance.Application.Internal.CommandServices;
using FoodSuit_Backend.Finance.Application.Internal.QueryServices;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Finance.Domain.Services;
using FoodSuit_Backend.Finance.Infrastructure.Persistence.EFC.Repositories;
using FoodSuit_Backend.Shared.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Apply Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Connection string is null");

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();

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