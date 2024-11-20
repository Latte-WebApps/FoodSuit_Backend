using FoodSuit_Backend.Dishes.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Dishes.Domain.Model.Commands;

public record CreateDishCommand(string Name, string Price, string Category, string Instruction, List<ProductId> ProductId);