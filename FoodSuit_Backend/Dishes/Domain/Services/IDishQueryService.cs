using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Model.Queries;

namespace FoodSuit_Backend.Dishes.Domain.Services;

public interface IDishQueryService
{
    /// <summary>
    /// Handle get dish by id query.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetDishByIdQuery"/> query
    /// </param>
    /// <returns>
    /// A <see cref="Dish"/> entity or null
    /// </returns>
    Task<Dish?> Handle(GetDishByIdQuery query);
    
    /// <summary>
    /// Handle get all dishes query.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllDishesQuery"/> query
    /// </param>
    /// <returns>
    /// A list of <see cref="Dish"/>
    /// </returns>
    Task<IEnumerable<Dish>> Handle(GetAllDishesQuery query);
    
    /// <summary>
    /// Handle get all dishes by category query.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllDishesByCategoryQuery"/> query
    /// </param>
    /// <returns>
    /// A list of <see cref="Dish"/> by category
    /// </returns>
    Task<IEnumerable<Dish>> Handle(GetAllDishesByCategoryQuery query);
}