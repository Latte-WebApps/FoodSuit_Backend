using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Dishes.Interfaces.REST.Transform;

public class CreateDishCommandFromResourceAssembler
{
    public static CreateDishCommand ToCommandFromResource(CreateDishResource resource)
    {
        return new CreateDishCommand(
            resource.Name,
            resource.Price,
            resource.Category,
            resource.Instruction,
            resource.Products);
    }
}