namespace FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

public record EntryTime
{
    public int Hours { get; init; }
    public int Minutes { get; init; }

    public EntryTime(int hours, int minutes)
    {
        if (hours < 0 || hours > 23)
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours must be between 0 and 23.");
        if (minutes < 0 || minutes > 59)
            throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be between 0 and 59.");

        Hours = hours;
        Minutes = minutes;
    }

    // Constructor sin parámetros con valores predeterminados
    public EntryTime() : this(0, 0) { }

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}
