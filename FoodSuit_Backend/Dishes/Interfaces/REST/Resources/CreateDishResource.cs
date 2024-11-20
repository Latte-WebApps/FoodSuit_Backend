using FoodSuit_Backend.Dishes.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Dishes.Interfaces.REST.Resources;

public record CreateDishResource(string Name, string Price, string Category, string Instruction)
{
    public List<ProductId> ProductId { get; set; }
}