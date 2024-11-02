using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Attendance.Infrastructure.Persistence.EFC.Repositories;

public class AttendanceRepository(AppDbContext context) : BaseRepository<EmployeeAttendance>(context), IAttendanceRepository
{
    public async Task<IEnumerable<EmployeeAttendance>> FindByEmployeeIdAsync(int employeeId, DateTime? startDate = null, DateTime? endDate = null)
    {
        var query = Context.Set<EmployeeAttendance>().Where(a => a.EmployeeId == employeeId);

        if (startDate.HasValue)
            query = query.Where(a => a.Date >= startDate.Value);
        
        if (endDate.HasValue)
            query = query.Where(a => a.Date <= endDate.Value);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<EmployeeAttendance>> FindByDateAsync(DateTime date)
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
}