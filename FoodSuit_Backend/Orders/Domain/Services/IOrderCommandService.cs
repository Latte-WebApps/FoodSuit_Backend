using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Model.Commands;

namespace FoodSuit_Backend.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
    Task<bool> DeleteOrderByIdAsync(DeleteOrderCommand command);
}