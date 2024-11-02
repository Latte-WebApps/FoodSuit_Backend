using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Queries;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Attendance.Domain.Services;

namespace FoodSuit_Backend.Attendance.Application.Internal.QueryServices;

public class AttendanceQueryService(IAttendanceRepository attendanceRepository) 
    : IAttendanceQueryService
{
    public async Task<IEnumerable<EmployeeAttendance>> Handle(GetAttendanceByEmployeeIdQuery query)
    {
        return await attendanceRepository.FindByEmployeeIdAsync(query.EmployeeId, query.StartDate, query.EndDate);
    }

    public async Task<IEnumerable<EmployeeAttendance>> Handle(GetDailyAttendanceByDateQuery query)
    {
        return await attendanceRepository.FindByDateAsync(query.Date);
    }

    public async Task<double> Handle(GetTotalHoursWorkedByEmployeeIdQuery query)
    {
        var attendances = await attendanceRepository.FindByEmployeeIdAsync(query.EmployeeId, query.StartDate, query.EndDate);
        return attendances.Sum(a => a.CalculateHoursWorked());
    }
}