using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Model.Queries;

namespace FoodSuit_Backend.Dishes.Domain.Services;

public interface IDishQueryService
{
    Task<Dish?> Handle(GetDishByIdQuery query);
    Task<IEnumerable<Dish>> Handle(GetAllDishesByCategoryQuery query);
}