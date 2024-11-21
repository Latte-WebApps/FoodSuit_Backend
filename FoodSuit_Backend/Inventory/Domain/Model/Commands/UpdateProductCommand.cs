namespace FoodSuit_Backend.Inventory.Domain.Model.Commands;

public record UpdateProductCommand(int Id, string Name, int Quantity, string ImageUrl, float Price)
{
};