namespace FoodSuit_Backend.Inventory.Domain.Model.ValueObjects;

public class Quantity
{
    public int Value { get; private set; }

    public Quantity(int value)
    {
        if (value < 0)
            throw new ArgumentException("Quantity cannot be negative.");
        Value = value;
    }

    // Necesario para EF Core
    private Quantity() { }
}
