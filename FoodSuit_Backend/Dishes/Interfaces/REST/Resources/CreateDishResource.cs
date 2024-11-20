using FoodSuit_Backend.Dishes.Domain.Model.Entities;

namespace FoodSuit_Backend.Dishes.Interfaces.REST.Resources;

public record CreateDishResource(string Name, string Price, string Category, string Instruction)
{
    public List<Products> Products { get; set; }
}