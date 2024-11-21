namespace FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

public record AttendanceResource(
    int Id,
    int EmployeeId,
    string Date,
    string CheckInTime,
    string? CheckOutTime
);