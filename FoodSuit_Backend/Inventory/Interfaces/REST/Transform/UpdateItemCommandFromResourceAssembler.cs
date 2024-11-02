using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;

namespace FoodSuit_Backend.Inventory.Interfaces.REST.Transform;

public static class UpdateItemCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource)
    {
        return new UpdateProductCommand(resource.Name, resource.Quantity, resource.ImageUrl, resource.Price); 
    }
}