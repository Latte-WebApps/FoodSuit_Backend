using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Model.Commands;

namespace FoodSuit_Backend.Dishes.Domain.Services;

public interface IDishCommandService
{
    Task<Dish?> Handle(int command);
    Task<Dish> Handle(CreateDishCommand createDishCommand);
    Task<bool> DeleteDishByIdAsync(DeleteDishCommand command);
}