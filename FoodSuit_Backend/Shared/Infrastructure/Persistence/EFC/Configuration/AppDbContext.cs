using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
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
        
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}