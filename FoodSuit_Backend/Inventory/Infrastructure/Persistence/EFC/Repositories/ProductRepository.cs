using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Domain.Model.ValueObjects;
using FoodSuit_Backend.Inventory.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public new async Task<Product?> FindByIdAsync(int id)
    {
        return await Context.Set<Product>()
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Product>?> FindByNameAsync(string name)
    {
        return await Context.Set<Product>().Where(i => i.Name == name).ToListAsync();
    }

    public async Task UpdateAsync(Product item)
    {
        Context.Set<Product>().Update(item);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>?> FindAllAsync()
    {
        return await Context.Set<Product>().ToListAsync();
    }

    public async Task<bool> ExistsByIdAndQuantityAsync(int id, int quantity)
    {
        var quantityValue = new Quantity(quantity);
        return await Context.Set<Product>().AnyAsync(q => q.Id == id && q.Quantity == quantity);
    }
}