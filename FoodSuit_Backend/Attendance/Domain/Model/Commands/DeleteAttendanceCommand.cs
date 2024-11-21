namespace FoodSuit_Backend.Attendance.Domain.Model.Commands;

/// <summary>
/// DeleteAttendanceCommand
/// This command is used to request the deletion of an attendance record by its ID.
/// </summary>
public record DeleteAttendanceCommand(int AttendanceId);