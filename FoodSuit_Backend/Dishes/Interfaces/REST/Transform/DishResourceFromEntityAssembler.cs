using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Dishes.Interfaces.REST.Transform;

public class DishResourceFromEntityAssembler
{
    public static DishResource ToResourceFromEntity(Dish entity)
    {
        return new DishResource(
            entity.Id,
            entity.Name,
            entity.Price,
            entity.Category);
    }
}