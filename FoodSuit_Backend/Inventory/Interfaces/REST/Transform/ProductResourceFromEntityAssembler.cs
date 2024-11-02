using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;
namespace FoodSuit_Backend.Inventory.Interfaces.Rest.Transform;


public static class ProductResourceFromEntityAssembler
{
    
    public static ProductResource ToResourceFromEntity(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "product cannot be null");
        }
        return new ProductResource(product.Id, product.Name, product.Quantity, product.ImageUrl, product.Price);
    }
}