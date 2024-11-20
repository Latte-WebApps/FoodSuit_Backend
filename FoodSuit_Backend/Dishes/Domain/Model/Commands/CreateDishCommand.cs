using FoodSuit_Backend.Dishes.Domain.Model.Entities;

namespace FoodSuit_Backend.Dishes.Domain.Model.Commands;

public record CreateDishCommand(string Name, string Price, string Category, string Instruction, List<Products> Products);