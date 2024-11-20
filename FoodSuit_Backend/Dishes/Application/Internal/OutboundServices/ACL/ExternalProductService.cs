namespace FoodSuit_Backend.Dishes.Application.Internal.OutboundServices.ACL;

public class ExternalProductService
{
    public async Task<ProductId?> FetchProductIdByName(string name)
    {
        // Fetch product id from external service
        var productId = await productsContextFacade.FetchProductIdByName(name);
        if (productId == 0) return await Task.FromResult<ProductId?>(null);
        return new ProductId(productId);
    }

    public async Task<ProductId?> CreateProduct(string name)
    {
        var productId = await productsContextFacade.CreateProduct(name);
        if (productId == 0) return await Task.FromResult<ProductId?>(null);
        return new ProductId(productId);
    }
}