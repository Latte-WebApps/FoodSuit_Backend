using FoodSuit_Backend.Inventory.Domain.Model.Queries;
using FoodSuit_Backend.Inventory.Domain.Services;

namespace FoodSuit_Backend.Inventory.Interfaces.ACL.Services;

public class ProductContextFacade(IProductCommandService productCommandService, IProductQueryService productQueryService): IProductContextFacade
{
    public  async Task<int> FetchProductIdByName(string name)
    {
        var getProductByNameQuery = new GetProductByNameQuery(name);
        var product = await productQueryService.Handle(getProductByNameQuery);
        return product?.Id ?? 0;
    }
}
