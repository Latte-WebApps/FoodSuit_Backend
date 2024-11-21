namespace FoodSuit_Backend.Attendance.Domain.Model.Queries;

/// <summary>
/// This query is used to calculate the total hours worked by a specific employee within a specified date range.
/// </summary>
public record GetTotalHoursWorkedByEmployeeIdQuery(
    int EmployeeId,
    string StartDate, // Formato: dd/MM/yyyy
    string EndDate // Formato: dd/MM/yyyy
);