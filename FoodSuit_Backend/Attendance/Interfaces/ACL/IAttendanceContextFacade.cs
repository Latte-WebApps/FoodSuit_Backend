namespace FoodSuit_Backend.Attendance.Interfaces.ACL;

public interface IAttendanceContextFacade
{
    Task<int> RegisterAttendance(int employeeId, DateTime date, DateTime checkInTime);
    Task<bool> UpdateCheckOut(int attendanceId, DateTime checkOutTime);
    Task<bool> DeleteAttendance(int attendanceId);
}