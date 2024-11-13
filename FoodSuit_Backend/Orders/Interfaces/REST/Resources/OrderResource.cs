namespace FoodSuit_Backend.Orders.Interfaces.REST.Resources;

public record OrderResource(int Id, string Table, string Status, DateTime Date, string Total);