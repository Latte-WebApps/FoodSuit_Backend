
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Attendance.Domain.Repositories;

/// <summary>
/// Interface for Attendance Repository
/// </summary>
public interface IAttendanceRepository : IBaseRepository<Attendance>
{
    Task<IEnumerable<Attendance>> FindByEmployeeIdAsync(int employeeId, DateTime? startDate = null, DateTime? endDate = null);
    
    Task<IEnumerable<Attendance>> FindByDateAsync(DateTime date);
    Task<Attendance?> GetByIdAsync(int id);
}