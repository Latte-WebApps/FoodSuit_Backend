using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Orders.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static CreateOrderResource ToResourceFromEntity(Order entity)
    {
        return new CreateOrderResource(
            entity.Id,
            entity.Table,
            entity.Status,
            entity.Date,
            entity.Total);
    }
}