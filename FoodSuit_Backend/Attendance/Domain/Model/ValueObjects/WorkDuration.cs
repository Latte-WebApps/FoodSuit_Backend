namespace FoodSuit_Backend.Attendance.Domain.Model.ValueObjects;

/// <summary>
/// WorkDuration Value Object
/// This object represents the total duration of hours worked, calculated from check-in and check-out times.
/// </summary>
public class WorkDuration
{
    public double Hours { get; private set; }

    public WorkDuration(CheckInTime checkIn, CheckOutTime checkOut)
    {
        if (checkOut.Value < checkIn.Value)
            throw new ArgumentException("Check-out time cannot be earlier than check-in time.");

        Hours = (checkOut.Value - checkIn.Value).TotalHours;
    }

    public override string ToString() => $"{Hours:F2} hours";

    public override bool Equals(object? obj)
    {
        return obj is WorkDuration other && Hours.Equals(other.Hours);
    }

    public override int GetHashCode() => Hours.GetHashCode();
}