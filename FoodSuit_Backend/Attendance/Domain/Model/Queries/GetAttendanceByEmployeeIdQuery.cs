namespace FoodSuit_Backend.Attendance.Domain.Model.Queries;

/// <summary>
/// This query is used to retrieve attendance records of a specific employee, optionally filtered by date or date range.
/// </summary>
public record GetAttendanceByEmployeeIdQuery(
    int EmployeeId,
    string? StartDate = null, // Formato: dd/MM/yyyy
    string? EndDate = null // Formato: dd/MM/yyyy
);