namespace FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;

public record UpdateProductResource(string Name, int Quantity, string ImageUrl, float Price)
{
}