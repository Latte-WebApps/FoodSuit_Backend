namespace FoodSuit_Backend.Inventory.Domain.Model.Commands;

public record UpdateProductCommand(string Name, int Quantity, string ImageUrl, float Price)
{
};