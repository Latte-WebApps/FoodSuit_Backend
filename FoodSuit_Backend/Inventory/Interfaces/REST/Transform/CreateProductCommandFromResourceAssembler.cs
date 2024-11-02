using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;

namespace FoodSuit_Backend.Inventory.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    /// <summary>
    /// Transform a CreateFavoriteSourceResource to a CreateFavoriteSourceCommand 
    /// </summary>
    /// <param name="resource">The <see cref="CreateProductResource"/> resource</param>
    /// <returns>An instance of <see cref="CreateProductCommand"/></returns>
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.Quantity, resource.ImageUrl, resource.Price);
    }
}