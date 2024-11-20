using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Services;
using FoodSuit_Backend.Attendance.Interfaces.ACL;

namespace FoodSuit_Backend.Attendance.Application.ACL;

/// <summary>
/// Implementation of the Attendance Context Facade
/// </summary>
public class AttendanceContextFacade(
    IAttendanceCommandService attendanceCommandService,
    IAttendanceQueryService attendanceQueryService
) : IAttendanceContextFacade
{
    /// <summary>
    /// Registers a new attendance record.
    /// </summary>
    public async Task<int> RegisterAttendance(int employeeId, string date, string checkInTime)
    {
        // Crea el comando para registrar asistencia
        var registerAttendanceCommand = new RegisterAttendanceCommand(employeeId, date, checkInTime, string.Empty);

        // Llama al servicio de comando para procesar el registro
        var attendance = await attendanceCommandService.Handle(registerAttendanceCommand);

        // Retorna el ID del registro o 0 si no se pudo registrar
        return attendance?.Id ?? 0;
    }

    /// <summary>
    /// Updates the check-out time of an attendance record.
    /// </summary>
    public async Task<bool> UpdateCheckOut(int attendanceId, string checkOutTime)
    {
        // Crea el comando para actualizar la hora de salida
        var updateCheckOutCommand = new UpdateCheckOutCommand(attendanceId, checkOutTime);

        // Llama al servicio de comando para actualizar el registro
        var attendance = await attendanceCommandService.Handle(attendanceId, updateCheckOutCommand);

        // Retorna verdadero si el registro fue actualizado exitosamente
        return attendance != null;
    }

    /// <summary>
    /// Deletes an attendance record.
    /// </summary>
    public async Task<bool> DeleteAttendance(int attendanceId)
    {
        // Crea el comando para eliminar el registro
        var deleteAttendanceCommand = new DeleteAttendanceCommand(attendanceId);

        // Llama al servicio de comando para eliminar el registro
        return await attendanceCommandService.Handle(deleteAttendanceCommand);
    }
}
