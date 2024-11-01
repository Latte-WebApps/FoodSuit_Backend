using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Model.Queries;
using FoodSuit_Backend.Dishes.Domain.Repositories;
using FoodSuit_Backend.Dishes.Domain.Services;

namespace FoodSuit_Backend.Dishes.Application.Internal.QueryServices;

public class DishQueryService(IDishRepository dishRepository) : IDishQueryService
{
    public async Task<Dish?> Handle(GetDishByIdQuery query)
    {
        return await dishRepository.FindDishByIdAsync(query.Id);
       
    }

    public async Task<IEnumerable<Dish>> Handle(GetAllDishesByCategoryQuery query)
    {
        return await dishRepository.FindByCategoryAsync(query.Category);
    }
}