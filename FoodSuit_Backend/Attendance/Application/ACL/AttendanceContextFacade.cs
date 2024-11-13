using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Services;
using FoodSuit_Backend.Attendance.Interfaces.ACL;

namespace FoodSuit_Backend.Attendance.Application.ACL;

public class AttendanceContextFacade(IAttendanceCommandService attendanceCommandService, IAttendanceQueryService attendanceQueryService) : IAttendanceContextFacade
{
    public async Task<int> RegisterAttendance(int employeeId, DateTime date, DateTime checkInTime)
    {
        var registerAttendanceCommand = new RegisterAttendanceCommand(employeeId, date, checkInTime, default);
        var attendance = await attendanceCommandService.Handle(registerAttendanceCommand);
        return attendance?.Id ?? 0;
    }

    public async Task<bool> UpdateCheckOut(int attendanceId, DateTime checkOutTime)
    {
        var updateCheckOutCommand = new UpdateCheckOutCommand(attendanceId, checkOutTime);
        var attendance = await attendanceCommandService.Handle(attendanceId, updateCheckOutCommand);
        return attendance != null;
    }

    public async Task<bool> DeleteAttendance(int attendanceId)
    {
        var deleteAttendanceCommand = new DeleteAttendanceCommand(attendanceId);
        return await attendanceCommandService.Handle(deleteAttendanceCommand);
    }
}