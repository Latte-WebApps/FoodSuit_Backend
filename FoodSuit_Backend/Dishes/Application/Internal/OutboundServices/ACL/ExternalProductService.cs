using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Interfaces.ACL.Services;

namespace FoodSuit_Backend.Dishes.Application.Internal.OutboundServices.ACL;

public class ExternalProductService(ProductContextFacade productContextFacade)
{
    
    public async Task<int> FetchProductIdByName(string name)
    {
        var product = await productContextFacade.FetchProductIdByName(name);
        if (product == 0) return await Task.FromResult<Product?>(null);
        return new Product(productId);
    }
}