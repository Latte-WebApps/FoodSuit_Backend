using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Attendance.Infrastructure.Persistence.EFC.Repositories;

public class AttendanceRepository(AppDbContext context) : BaseRepository<EmployeeAttendance>(context), IAttendanceRepository
{
    public async Task<IEnumerable<EmployeeAttendance>> FindByEmployeeIdAsync(int employeeId, string? startDate = null, string? endDate = null)
    {
        var query = Context.Set<EmployeeAttendance>().Where(a => a.EmployeeId == employeeId);

        // Filtrar por rango de fechas si se proporciona
        if (!string.IsNullOrEmpty(startDate))
        {
            query = query.Where(a => string.Compare(a.Date, startDate) >= 0);
        }

        if (!string.IsNullOrEmpty(endDate))
        {
            query = query.Where(a => string.Compare(a.Date, endDate) <= 0);
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<EmployeeAttendance>> FindByDateAsync(string date)
    {
        return await Context.Set<EmployeeAttendance>()
            .Where(a => a.Date == date)
            .ToListAsync();
    }

    public async Task<EmployeeAttendance?> GetByIdAsync(int id)
    {
        return await Context.Set<EmployeeAttendance>()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<EmployeeAttendance>?> FindAllAsync()
    {
        return await Context.Set<EmployeeAttendance>().ToListAsync();
    }
}