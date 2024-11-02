using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Attendance.Domain.Repositories;

/// <summary>
/// Interface for Attendance Repository
/// </summary>
public interface IAttendanceRepository : IBaseRepository<EmployeeAttendance>
{
    Task<IEnumerable<EmployeeAttendance>> FindByEmployeeIdAsync(int employeeId, DateTime? startDate = null, DateTime? endDate = null);
    Task<IEnumerable<EmployeeAttendance>> FindByDateAsync(DateTime date);
    Task<EmployeeAttendance?> GetByIdAsync(int id);
    Task<IEnumerable<EmployeeAttendance>?> FindAllAsync();
}