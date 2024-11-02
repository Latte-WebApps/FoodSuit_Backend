using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Queries;

namespace FoodSuit_Backend.Attendance.Domain.Services;

public interface IAttendanceQueryService
{
    Task<IEnumerable<EmployeeAttendance>> Handle(GetAttendanceByEmployeeIdQuery query);
    Task<IEnumerable<EmployeeAttendance>> Handle(GetDailyAttendanceByDateQuery query);
    Task<double> Handle(GetTotalHoursWorkedByEmployeeIdQuery query);
}