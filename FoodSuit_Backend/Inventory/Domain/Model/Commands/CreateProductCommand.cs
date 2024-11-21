namespace FoodSuit_Backend.Inventory.Domain.Model.Commands;

public record CreateProductCommand(string Name, int Quantity, string Image, float Price)
{
}