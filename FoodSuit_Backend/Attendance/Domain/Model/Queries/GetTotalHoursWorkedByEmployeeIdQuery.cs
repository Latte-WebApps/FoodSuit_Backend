namespace FoodSuit_Backend.Attendance.Domain.Model.Queries;

/// <summary>
/// GetTotalHoursWorkedByEmployeeIdQuery
/// This query is used to calculate the total hours worked by a specific employee within a specified date range.
/// </summary>
public record GetTotalHoursWorkedByEmployeeIdQuery(
    int EmployeeId,
    DateTime StartDate,
    DateTime EndDate);