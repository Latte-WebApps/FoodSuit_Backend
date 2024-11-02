using FoodSuit_Backend.Attendance.Domain.Model.Commands;

namespace FoodSuit_Backend.Attendance.Domain.Model.Aggregates;

/// <summary>
/// Attendance Aggregate
/// This class represents the Attendance aggregate. It is used to store the attendance record of an employee, including the check-in and check-out times.
/// </summary>
public class Attendance
{
    public int Id { get; private set; }
    public int EmployeeId { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime CheckInTime { get; private set; }
    public DateTime CheckOutTime { get; private set; }

    protected Attendance()
    {
        Date = DateTime.MinValue;
        CheckInTime = DateTime.MinValue;
        CheckOutTime = DateTime.MinValue;
    }

    /// <summary>
    /// Constructor for the Attendance aggregate
    /// </summary>
    /// <remarks>
    /// The constructor is the command handler for the RegisterAttendanceCommand. It initializes the Attendance aggregate with the EmployeeId, Date, CheckInTime, and CheckOutTime.
    /// </remarks>
    /// <param name="command">The RegisterAttendanceCommand command</param>
    public Attendance(RegisterAttendanceCommand command)
    {
        EmployeeId = command.EmployeeId;
        Date = command.Date;
        CheckInTime = command.CheckInTime;
        CheckOutTime = command.CheckOutTime;
    }

    /// <summary>
    /// Updates the check-out time of the attendance record.
    /// </summary>
    /// <param name="checkOutTime">The time at which the employee checked out</param>
    public void UpdateCheckOutTime(DateTime checkOutTime)
    {
        CheckOutTime = checkOutTime;
    }

    /// <summary>
    /// Calculates the total hours worked based on the check-in and check-out times.
    /// </summary>
    /// <returns>The total hours worked as a double</returns>
    public double CalculateHoursWorked()
    {
        return (CheckOutTime - CheckInTime).TotalHours;
    }
}
