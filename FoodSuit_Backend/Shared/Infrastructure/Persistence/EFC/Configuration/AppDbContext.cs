using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Finance Context
        builder.Entity<Report>().HasKey(r => r.Id);
        builder.Entity<Report>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(r => r.Description).IsRequired().HasMaxLength(100);
        builder.Entity<Report>().HasDiscriminator<string>("report_type")
            .HasValue<Report>("Expense")
            .HasValue<Report>("Earning");
        builder.Entity<Report>().Property(r => r.Date).IsRequired();
        builder.Entity<Report>().Property(r => r.Amount).IsRequired();
        
        // Replace with actual foreign keys
        builder.Entity<Report>().Property(r => r.OrdersId).IsRequired();
        builder.Entity<Report>().Property(r => r.ProductsId).IsRequired();
        
        // TODO: Add relationships between tables
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}