namespace FoodSuit_Backend.Attendance.Domain.Model.ValueObjects;

/// <summary>
/// CheckInTime Value Object
/// This object represents the check-in time of an attendance record.
/// </summary>
public class CheckInTime
{
    public DateTime Value { get; private set; }

    public CheckInTime(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("Check-in time cannot be the default value.");

        Value = value;
    }

    public override string ToString() => Value.ToString("HH:mm");

    public override bool Equals(object? obj)
    {
        return obj is CheckInTime other && Value.Equals(other.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();
}