using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Domain.Repositories;
using FoodSuit_Backend.Dishes.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Dishes.Application.Internal.CommandServices;

public class DishCommandService(IDishRepository dishRepository, IUnitOfWork unitOfWork) : IDishCommandService
{
    public async Task<Dish> Handle(CreateDishCommand command)
    {
        var dish = new Dish(command);
        try
        {
            await dishRepository.AddAsync(dish);
            await unitOfWork.CompleteAsync();
            return dish;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the dish: {e.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteDishByIdAsync(DeleteDishCommand command)
    {
        try
        {
            var dish = await dishRepository.FindDishByIdAsync(command.Id);
            if (dish == null)
            {
                Console.WriteLine($"Dish with ID {command.Id} not found.");
                return false;
            }
            dishRepository.Remove(dish);
            await unitOfWork.CompleteAsync();
            Console.WriteLine($"Dish with ID {command.Id} deleted successfully.");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the dish: {e.Message}");
            return false;
        }
    }

    public async Task<Dish?> Handle(int dishId)
    {
        var dish = await dishRepository.FindDishByIdAsync(dishId);
        if (dish == null)
        {
            Console.WriteLine($"Dish with ID {dishId} not found.");
            return null;
        }
        return dish;
    }
}