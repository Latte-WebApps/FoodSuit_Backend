namespace FoodSuit_Backend.Dishes.Domain.Model.Commands;

public record CreateDishCommand(string Name, string Price, string Category);