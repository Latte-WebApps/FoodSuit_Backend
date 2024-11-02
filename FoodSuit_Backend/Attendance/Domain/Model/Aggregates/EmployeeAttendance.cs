using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Attendance.Domain.Model.Aggregates;

/// <summary>
/// This class represents the Attendance aggregate. It is used to store the attendance record of an employee.
/// </summary>
public partial class EmployeeAttendance
{
    public int Id { get; }
    public int EmployeeId { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CheckInTime { get; private set; }
    public DateTime CheckOutTime { get; private set; }

    // Constructor sin parámetros para flexibilidad
    public EmployeeAttendance()
    {
        Date = DateTime.MinValue;
        CheckInTime = DateTime.MinValue;
        CheckOutTime = DateTime.MinValue;
    }

    // Constructor con comando para registro inicial de asistencia
    public EmployeeAttendance(RegisterAttendanceCommand command)
    {
        EmployeeId = command.EmployeeId;
        Date = command.Date;
        CheckInTime = command.CheckInTime;
        CheckOutTime = command.CheckOutTime;
    }

    // Método de actualización para modificar el registro de asistencia
    public void UpdateAttendance(DateTime checkInTime, DateTime checkOutTime)
    {
        CheckInTime = checkInTime;
        CheckOutTime = checkOutTime;
    }

    public void UpdateCheckOutTime(DateTime checkOutTime)
    {
        CheckOutTime = checkOutTime;
    }

    public double CalculateHoursWorked()
    {
        return (CheckOutTime - CheckInTime).TotalHours;
    }
}