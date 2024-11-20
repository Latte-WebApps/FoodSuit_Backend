namespace FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

public record RegisterAttendanceResource(int EmployeeId,
    string Date,
    string CheckInTime,
    string CheckOutTime);