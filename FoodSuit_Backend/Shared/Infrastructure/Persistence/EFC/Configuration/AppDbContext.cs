using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.IAM.Domain.Model.Aggregates;
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
        
        builder.Entity<EmployeeAttendance>().HasKey(f => f.Id);
        builder.Entity<EmployeeAttendance>().Property(f => f.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EmployeeAttendance>().Property(f => f.EmployeeId)
            .IsRequired();
        builder.Entity<EmployeeAttendance>().Property(f => f.Date)
            .IsRequired();
        builder.Entity<EmployeeAttendance>().Property(f => f.CheckInTime)
            .IsRequired();
        builder.Entity<EmployeeAttendance>().Property(f => f.CheckOutTime);
        
        
        builder.Entity<Dish>().ToTable("Dishes");
        builder.Entity<Dish>().HasKey(d => d.Id);
        builder.Entity<Dish>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Dish>().Property(d => d.Name).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Category).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Price).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Instruction).IsRequired();
        builder.Entity<Dish>().Property(d=>d.Products).IsRequired();
        
        
        
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(o=>o.Status).IsRequired();
        builder.Entity<Order>().Property(o=>o.Date).IsRequired();
        builder.Entity<Order>().Property(o=>o.Table).IsRequired();
        
        // Product Context
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
        
        //IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }




}