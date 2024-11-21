using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Attendance.Domain.Repositories;

/// <summary>
/// Interface for Attendance Repository
/// </summary>
public interface IAttendanceRepository : IBaseRepository<EmployeeAttendance>
{
    /// <summary>
    /// Finds attendance records by employee ID, optionally filtered by a date range.
    /// </summary>
    /// <param name="employeeId">The ID of the employee.</param>
    /// <param name="startDate">The start date in dd/MM/yyyy format (optional).</param>
    /// <param name="endDate">The end date in dd/MM/yyyy format (optional).</param>
    /// <returns>A list of attendance records.</returns>
    Task<IEnumerable<EmployeeAttendance>> FindByEmployeeIdAsync(int employeeId, string? startDate = null, string? endDate = null);

    /// <summary>
    /// Finds attendance records by a specific date.
    /// </summary>
    /// <param name="date">The date in dd/MM/yyyy format.</param>
    /// <returns>A list of attendance records for the given date.</returns>
    Task<IEnumerable<EmployeeAttendance>> FindByDateAsync(string date);

    /// <summary>
    /// Gets an attendance record by its ID.
    /// </summary>
    /// <param name="id">The ID of the attendance record.</param>
    /// <returns>The attendance record, or null if not found.</returns>
    Task<EmployeeAttendance?> GetByIdAsync(int id);

    /// <summary>
    /// Finds all attendance records.
    /// </summary>
    /// <returns>A list of all attendance records.</returns>
    Task<IEnumerable<EmployeeAttendance>?> FindAllAsync();
}