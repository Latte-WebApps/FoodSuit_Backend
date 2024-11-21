namespace FoodSuit_Backend.Attendance.Interfaces.ACL;

/// <summary>
/// Interface for the Attendance Context Facade
/// </summary>
public interface IAttendanceContextFacade
{
    /// <summary>
    /// Registers a new attendance record.
    /// </summary>
    Task<int> RegisterAttendance(int employeeId, string date, string checkInTime);

    /// <summary>
    /// Updates the check-out time of an attendance record.
    /// </summary>
    Task<bool> UpdateCheckOut(int attendanceId, string checkOutTime);

    /// <summary>
    /// Deletes an attendance record.
    /// </summary>
    Task<bool> DeleteAttendance(int attendanceId);
}