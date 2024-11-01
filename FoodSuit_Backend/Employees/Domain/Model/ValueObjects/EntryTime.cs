namespace FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

public record EntryTime()
{
    public int Hours { get; }
    public int Minutes { get; }

    public EntryTime(int hours, int minutes) : this()
    {
        if (hours is < 0 or > 23)
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours must be between 0 and 23.");
        if (minutes is < 0 or > 59)
            throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be between 0 and 59.");

        Hours = hours;
        Minutes = minutes;
    }
    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}