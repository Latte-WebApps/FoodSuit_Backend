using FoodSuit_Backend.Dishes.Domain.Model.Entities;
using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Interfaces.ACL.Services;

namespace FoodSuit_Backend.Dishes.Application.Internal.OutboundServices.ACL;

public class ExternalProductService(ProductContextFacade productContextFacade)
{
    
    public async Task<Products?> FetchProductIdByName(string name)
    {
        var product = await productContextFacade.FetchProductIdByName(name);
        if (product == 0) return await Task.FromResult<Products?>(null);
        return new Products(product);
    }
}