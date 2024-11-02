using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Model.Queries;
using FoodSuit_Backend.Orders.Domain.Repositories;
using FoodSuit_Backend.Orders.Domain.Services;
using Order = Mysqlx.Crud.Order;

namespace FoodSuit_Backend.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Order>> Handle(GetOrdersByStatusQuery query)
    {
        return await orderRepository.FindByStatusAsync(query.Status);
    }

    public async Task<Domain.Model.Aggregates.Order?> Handle(GetOrdersByDateQuery query)
    {
        return await orderRepository.FindByDateAsync(query.Date);
    }

    public async Task<Domain.Model.Aggregates.Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindOrderByIdAsync(query.Id);
    }
}
