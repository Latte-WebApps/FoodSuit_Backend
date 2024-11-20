using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Queries;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Attendance.Domain.Services;

namespace FoodSuit_Backend.Attendance.Application.Internal.QueryServices;

public class AttendanceQueryService(IAttendanceRepository attendanceRepository) 
    : IAttendanceQueryService
{
    /// <summary>
    /// Handles the query to retrieve attendance records by employee ID, optionally filtered by date range.
    /// </summary>
    public async Task<IEnumerable<EmployeeAttendance>> Handle(GetAttendanceByEmployeeIdQuery query)
    {
        // Llama al repositorio con las fechas como cadenas
        return await attendanceRepository.FindByEmployeeIdAsync(query.EmployeeId, query.StartDate, query.EndDate);
    }

    /// <summary>
    /// Handles the query to retrieve daily attendance records for a specific date.
    /// </summary>
    public async Task<IEnumerable<EmployeeAttendance>> Handle(GetDailyAttendanceByDateQuery query)
    {
        // Llama al repositorio para buscar registros en la fecha especificada
        return await attendanceRepository.FindByDateAsync(query.Date);
    }

    /// <summary>
    /// Handles the query to calculate the total hours worked by an employee in a date range.
    /// </summary>
    public async Task<double> Handle(GetTotalHoursWorkedByEmployeeIdQuery query)
    {
        // Recupera los registros de asistencia del empleado en el rango de fechas
        var attendances = await attendanceRepository.FindByEmployeeIdAsync(query.EmployeeId, query.StartDate, query.EndDate);

        // Suma las horas trabajadas
        return attendances.Sum(a => a.CalculateHoursWorked());
    }

    /// <summary>
    /// Handles the query to retrieve all attendance records.
    /// </summary>
    public async Task<IEnumerable<EmployeeAttendance>> Handle(GetAllAttendancesQuery query)
    {
        // Recupera todos los registros o devuelve una lista vacía si no hay resultados
        return (await attendanceRepository.FindAllAsync()) ?? Enumerable.Empty<EmployeeAttendance>();
    }
}
