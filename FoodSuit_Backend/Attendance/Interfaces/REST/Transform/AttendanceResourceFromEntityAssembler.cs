using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Attendance.Interfaces.REST.Transform;

public static class AttendanceResourceFromEntityAssembler
{
    public static AttendanceResource ToResourceFromEntity(EmployeeAttendance attendance)
    {
        return new AttendanceResource(
            attendance.Id,
            attendance.EmployeeId,
            attendance.Date,
            attendance.CheckInTime,
            attendance.CheckOutTime
        );
    }
}