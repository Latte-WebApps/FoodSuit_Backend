namespace FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;

public record ProductResource(int Id, string Name, int Quantity, string ImageUrl, float Price);