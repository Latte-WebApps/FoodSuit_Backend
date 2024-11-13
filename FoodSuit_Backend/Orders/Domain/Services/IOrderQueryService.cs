using FoodSuit_Backend.Orders.Domain.Model.Queries;
using Mysqlx.Crud;
using Order = FoodSuit_Backend.Orders.Domain.Model.Aggregates.Order;

namespace FoodSuit_Backend.Orders.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<IEnumerable<Model.Aggregates.Order>> Handle(GetOrdersByStatusQuery query);
    Task<Model.Aggregates.Order?> Handle(GetOrdersByDateQuery query);
    Task<Model.Aggregates.Order?> Handle(GetOrderByIdQuery query);
}