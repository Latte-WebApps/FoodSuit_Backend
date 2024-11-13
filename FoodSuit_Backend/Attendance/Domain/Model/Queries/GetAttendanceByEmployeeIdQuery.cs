namespace FoodSuit_Backend.Attendance.Domain.Model.Queries;

/// <summary>
/// GetAttendanceByEmployeeQuery
/// This query is used to retrieve attendance records of a specific employee, optionally filtered by date or date range.
/// </summary>
public record GetAttendanceByEmployeeIdQuery(
    int EmployeeId,
    DateTime? StartDate = null,
    DateTime? EndDate = null);