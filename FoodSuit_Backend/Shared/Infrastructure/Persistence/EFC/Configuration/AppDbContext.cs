using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
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
        
        //Orders Context
        
        builder.Entity<Dish>().ToTable("Dishes");
        builder.Entity<Dish>().HasKey(d => d.Id);
        builder.Entity<Dish>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Dish>().Property(d => d.Name).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Category).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Price).IsRequired();
        
        
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(o=>o.Status).IsRequired();
        builder.Entity<Order>().Property(o=>o.Date).IsRequired();
        builder.Entity<Order>().Property(o=>o.Table).IsRequired();
        
        
        

        
        builder.UseSnakeCaseNamingConvention();

    }
    
}