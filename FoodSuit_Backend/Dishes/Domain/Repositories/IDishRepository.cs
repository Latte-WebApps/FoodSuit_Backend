using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Dishes.Domain.Repositories;

public interface IDishRepository : IBaseRepository<Dish>
{
    Task<Dish?> FindDishByIdAsync(int id);
    Task<IEnumerable<Dish>> FindByCategoryAsync(string category);
}