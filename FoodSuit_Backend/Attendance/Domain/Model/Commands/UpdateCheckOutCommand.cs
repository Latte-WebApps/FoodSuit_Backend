namespace FoodSuit_Backend.Attendance.Domain.Model.Commands;

/// <summary>
/// UpdateCheckOutCommand
/// This command is used to update the check-out time of an existing attendance record.
/// </summary>
public record UpdateCheckOutCommand(int EmployeeId, DateTime CheckOutTime);