namespace FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;

public record CreateProductResource(string Name, int Quantity, string ImageUrl, float Price)
{
};