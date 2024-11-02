namespace FoodSuit_Backend.Attendance.Domain.Model.Commands;

/// <summary>
/// RegisterAttendanceCommand
/// This command is used to register a new attendance record for an employee, including the check-in and check-out times.
/// </summary>
public record RegisterAttendanceCommand(
    int EmployeeId,
    DateTime Date,
    DateTime CheckInTime,
    DateTime CheckOutTime);