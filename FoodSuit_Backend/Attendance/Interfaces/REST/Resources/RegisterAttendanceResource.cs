namespace FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

public record RegisterAttendanceResource(int EmployeeId,
    DateTime Date,
    DateTime CheckInTime,
    DateTime CheckOutTime);