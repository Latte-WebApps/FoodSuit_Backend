using FoodSuit_Backend.Dishes.Domain.Model.ValueObjects;
using FoodSuit_Backend.Inventory.Interfaces.ACL.Services;

namespace FoodSuit_Backend.Dishes.Application.Internal.OutboundServices.ACL;

public class ExternalProductService(ProductContextFacade productContextFacade)
{
    
    public async Task<ProductId?> FetchProductIdByName(string name)
    {
        var product = await productContextFacade.FetchProductIdByName(name);
        if (product == 0) return await Task.FromResult<ProductId?>(null);
        return new ProductId(product);
    }
}