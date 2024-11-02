using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
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

        
        // Product Entity Configuration 
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(f => f.Name)
            .IsRequired();
        builder.Entity<Product>().Property(f => f.ImageUrl)
            .IsRequired();
        builder.Entity<Product>().Property(f => f.Price)
            .IsRequired();
        builder.Entity<Product>().Property(f => f.Quantity)
            .IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }




}