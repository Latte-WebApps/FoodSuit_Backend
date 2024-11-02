using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Attendance.Domain.Model.Aggregates;

/// <summary>
/// This class represents the Attendance aggregate. It is used to store the attendance record of an employee.
/// </summary>
public partial class Attendance
{
    public int Id { get; private set; }
    public int EmployeeId { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CheckInTime { get; private set; }
    public DateTime CheckOutTime { get; private set; }

    public Attendance(RegisterAttendanceCommand command)
    {
        EmployeeId = command.EmployeeId;
        Date = command.Date;
        CheckInTime = command.CheckInTime;
        CheckOutTime = command.CheckOutTime;
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