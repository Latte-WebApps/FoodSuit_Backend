using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Attendance.Interfaces.REST.Transform;

public static class RegisterAttendanceCommandFromResourceAssembler
{
    public static RegisterAttendanceCommand ToCommandFromResource(RegisterAttendanceResource resource)
    {
        return new RegisterAttendanceCommand(resource.EmployeeId, resource.Date, resource.CheckInTime, default);
    }
}