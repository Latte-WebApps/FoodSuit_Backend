using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Inventory.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<Product?> FindByIdAsync(int id);
    Task<IEnumerable<Product>?> FindByNameAsync(string name);
    Task UpdateAsync(Product product );
    Task<IEnumerable<Product>?> FindAllAsync();
    Task<bool> ExistsByIdAndQuantityAsync(int id, int quantity);

}