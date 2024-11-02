namespace FoodSuit_Backend.Attendance.Domain.Model.ValueObjects;

/// <summary>
/// CheckOutTime Value Object
/// This object represents the check-out time of an attendance record.
/// </summary>
public class CheckOutTime
{
    public DateTime Value { get; private set; }

    public CheckOutTime(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("Check-out time cannot be the default value.");
        
        Value = value;
    }

    public override string ToString() => Value.ToString("HH:mm");

    public override bool Equals(object? obj)
    {
        return obj is CheckOutTime other && Value.Equals(other.Value);
    }

    public override int GetHashCode() => Value.GetHashCode();
}