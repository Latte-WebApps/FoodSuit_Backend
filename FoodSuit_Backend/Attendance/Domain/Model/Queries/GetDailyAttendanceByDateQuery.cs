namespace FoodSuit_Backend.Attendance.Domain.Model.Queries;

/// <summary>
/// This query is used to retrieve attendance records for all employees for a specific date.
/// </summary>
public record GetDailyAttendanceByDateQuery(string Date); // Formato: dd/MM/yyyy