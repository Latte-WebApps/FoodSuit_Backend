using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Commands;

namespace FoodSuit_Backend.Attendance.Domain.Services;

public interface IAttendanceCommandService
{
    Task<EmployeeAttendance?> Handle(RegisterAttendanceCommand command);
    Task<EmployeeAttendance?> Handle(int id, UpdateCheckOutCommand command);
    Task<bool> Handle(DeleteAttendanceCommand command);
}