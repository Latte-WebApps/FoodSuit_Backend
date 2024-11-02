using FoodSuit_Backend.Dishes.Domain.Model.Aggregates;
using FoodSuit_Backend.Dishes.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Dishes.Infrastructure.Persistence.EFC.Repositories;

public class DishRepository(AppDbContext context) 
    : BaseRepository<Dish>(context), IDishRepository
{
    public async Task<Dish?> FindDishByIdAsync(int id)
    {
        return await Context.Set<Dish>().FirstOrDefaultAsync(f=> f.Id == id);
    }

    public async Task<IEnumerable<Dish>> FindByCategoryAsync(string category)
    {
        return await Context.Set<Dish>().Where(f=> f.Category == category).ToListAsync();
    }
}   