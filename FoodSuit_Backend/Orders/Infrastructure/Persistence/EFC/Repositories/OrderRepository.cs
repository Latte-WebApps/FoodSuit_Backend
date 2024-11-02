using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Orders.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context)
: BaseRepository<Order>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>> FindByStatusAsync(string status)
    {
        return await Context.Set<Order>().Where(f => f.Status == status).ToListAsync();
    }
    
    public async Task<Order?> FindByStatusAndDateAsync(string status, DateTime date)
    {
        return await Context.Set<Order>().FirstOrDefaultAsync(f => f.Status == status && f.Date == date);
    }
    
    public async Task<Order?> FindByDateAsync(DateTime date)
    {
        return await Context.Set<Order>().FirstOrDefaultAsync(f => f.Date == date);
    }
    
    public async Task<Order?> FindOrderByIdAsync(int id)
    {
        return await Context.Set<Order>().FirstOrDefaultAsync(f => f.Id == id);
    }
}