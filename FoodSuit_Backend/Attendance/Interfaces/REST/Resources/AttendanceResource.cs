namespace FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

public record AttendanceResource(
    int Id,
    int EmployeeId,
    DateTime Date,
    DateTime CheckInTime,
    DateTime? CheckOutTime
);