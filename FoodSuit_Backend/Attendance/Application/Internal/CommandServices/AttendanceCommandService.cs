using FoodSuit_Backend.Attendance.Domain.Services;
using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Attendance.Application.Internal.CommandServices;

public class AttendanceCommandService(IAttendanceRepository attendanceRepository, IUnitOfWork unitOfWork) 
    : IAttendanceCommandService
{
    /// <summary>
    /// Handles the creation of a new attendance record.
    /// </summary>
    /// <param name="command">The command containing the attendance details.</param>
    /// <returns>The created attendance record, or null if an error occurs.</returns>
    public async Task<EmployeeAttendance?> Handle(RegisterAttendanceCommand command)
    {
        var attendance = new EmployeeAttendance(command);

        try
        {
            await attendanceRepository.AddAsync(attendance);
            await unitOfWork.CompleteAsync();
            return attendance;
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            Console.WriteLine($"Error creating attendance: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Handles the update of an existing attendance record's check-out time.
    /// </summary>
    /// <param name="id">The ID of the attendance record.</param>
    /// <param name="command">The command containing the updated check-out time.</param>
    /// <returns>The updated attendance record, or null if not found or an error occurs.</returns>
    public async Task<EmployeeAttendance?> Handle(int id, UpdateCheckOutCommand command)
    {
        // Buscar la asistencia por ID
        var attendance = await attendanceRepository.GetByIdAsync(id);

        // Si no se encuentra, retornar null
        if (attendance == null)
        {
            return null; // Attendance not found
        }

        // Actualizar la hora de salida usando el método de la entidad
        attendance.UpdateCheckOutTime(command.CheckOutTime);

        try
        {
            // Guardar los cambios en el repositorio
            await unitOfWork.UpdateAsync(attendance);
            await unitOfWork.CompleteAsync();
            return attendance;
        }
        catch (Exception ex)
        {
            // Manejar errores con un log opcional y relanzar la excepción
            Console.WriteLine($"Error updating attendance: {ex.Message}");
            throw new Exception("Error updating attendance", ex);
        }
    }

    /// <summary>
    /// Handles the deletion of an attendance record.
    /// </summary>
    /// <param name="command">The command containing the ID of the attendance record to delete.</param>
    /// <returns>True if the record was deleted successfully, otherwise false.</returns>
    public async Task<bool> Handle(DeleteAttendanceCommand command)
    {
        var attendance = await attendanceRepository.GetByIdAsync(command.AttendanceId);

        if (attendance == null)
        {
            return false; // Attendance not found
        }

        try
        {
            await unitOfWork.RemoveAsync(attendance);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            Console.WriteLine($"Error deleting attendance: {ex.Message}");
            return false;
        }
    }
}
