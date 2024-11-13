using FoodSuit_Backend.Orders.Domain.Model.Commands;
using FoodSuit_Backend.Orders.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Orders.Interfaces.REST.Transform;

public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(resource.Table, resource.Status, resource.Date, resource.Total);
    }
}