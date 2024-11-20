using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Domain.Model.Queries;
using FoodSuit_Backend.Inventory.Domain.Repositories;
using FoodSuit_Backend.Inventory.Domain.Services;

namespace FoodSuit_Backend.Inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query)
    {
        return (await productRepository.FindAllAsync()) ?? Enumerable.Empty<Product>();
    }

    public Task<Product?> Handle(GetProductByNameQuery query)
    {
        return productRepository.FindProductByNameAsync(query.Name);
    }
}