using FoodSuit_Backend.Attendance.Domain.Model.Commands;

namespace FoodSuit_Backend.Attendance.Domain.Model.Aggregates;

/// <summary>
/// Represents the Attendance aggregate. It is used to store the attendance record of an employee.
/// </summary>
public partial class EmployeeAttendance
{
    public int Id { get; private set; } // Unique identifier
    public int EmployeeId { get; private set; } // Employee ID
    public string Date { get; private set; } // Date in dd/MM/yyyy format
    public string CheckInTime { get; private set; } // Check-in time in HH:mm format
    public string? CheckOutTime { get; private set; } // Check-out time in HH:mm format (optional)

    /// <summary>
    /// Default constructor for flexibility.
    /// </summary>
    public EmployeeAttendance()
    {
        Date = string.Empty;
        CheckInTime = string.Empty;
        CheckOutTime = null;
    }

    /// <summary>
    /// Constructor to create a new attendance record using RegisterAttendanceCommand.
    /// </summary>
    /// <param name="command">The command containing the attendance details.</param>
    public EmployeeAttendance(RegisterAttendanceCommand command)
    {
        EmployeeId = command.EmployeeId;
        Date = command.Date;
        CheckInTime = command.CheckInTime;
        CheckOutTime = command.CheckOutTime;
    }

    /// <summary>
    /// Constructor to update check-out time using UpdateCheckOutCommand.
    /// </summary>
    /// <param name="command">The command containing the updated check-out time.</param>
    public EmployeeAttendance(UpdateCheckOutCommand command)
    {
        EmployeeId = command.EmployeeId;
        CheckOutTime = command.CheckOutTime;
    }

    /// <summary>
    /// Updates the check-out time for the attendance record.
    /// </summary>
    /// <param name="checkOutTime">The new check-out time in HH:mm format.</param>
    public void UpdateCheckOutTime(string checkOutTime)
    {
        if (string.IsNullOrWhiteSpace(checkOutTime))
            throw new ArgumentException("CheckOutTime cannot be null or empty.");

        CheckOutTime = checkOutTime;
    }

    /// <summary>
    /// Calculates the total hours worked using CheckInTime and CheckOutTime.
    /// </summary>
    /// <returns>Total hours worked as a double.</returns>
    public double CalculateHoursWorked()
    {
        if (string.IsNullOrWhiteSpace(CheckInTime) || string.IsNullOrWhiteSpace(CheckOutTime))
            throw new InvalidOperationException("Both CheckInTime and CheckOutTime must be set to calculate hours worked.");

        var checkIn = TimeSpan.Parse(CheckInTime);
        var checkOut = TimeSpan.Parse(CheckOutTime);

        if (checkOut < checkIn)
            throw new InvalidOperationException("CheckOutTime cannot be earlier than CheckInTime.");

        return (checkOut - checkIn).TotalHours;
    }
}
