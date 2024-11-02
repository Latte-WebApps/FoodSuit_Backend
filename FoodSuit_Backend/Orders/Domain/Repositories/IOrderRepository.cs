using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order?> FindOrderByIdAsync(int id);
    
    Task<IEnumerable<Order>> FindByStatusAsync(string status);
    
    Task<Order?> FindByStatusAndDateAsync(string status, DateTime date);
    
    Task<Order?> FindByDateAsync(DateTime date);
}