using System.Net.Mime;
using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Domain.Model.Queries;
using FoodSuit_Backend.Dishes.Domain.Services;
using FoodSuit_Backend.Dishes.Interfaces.REST.Resources;
using FoodSuit_Backend.Dishes.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FoodSuit_Backend.Dishes.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class DishesController( 
    IDishCommandService dishCommandService,
    IDishQueryService dishQueryService
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromBody] CreateDishResource resource)
    {
        var createDishCommand = CreateDishCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await dishCommandService.Handle(createDishCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetDishById), new {id = result.Id}, DishResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]

    public async Task<ActionResult> GetDishById(int id)
    {
        var getDishByIdQuery = new GetDishByIdQuery(id);
        var result = await dishQueryService.Handle(getDishByIdQuery);
        if (result is null) return NotFound();
        var resource = DishResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    private async Task<ActionResult> GetAllDishesByCategory(string category)
    {
        var getAllDishesByCategoryQuery = new GetAllDishesByCategoryQuery(category);
        var result = await dishQueryService.Handle(getAllDishesByCategoryQuery);
        if (result is null) return NotFound();
        var resource = result.Select(DishResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    [HttpDelete("{dishId:int}")]
    public async Task<IActionResult> DeleteDish(int dishId)
    {
        var deleteCommand = new DeleteDishCommand(dishId);
        var result = await dishCommandService.DeleteDishByIdAsync(deleteCommand);
        if (!result) return NotFound($"Dish with id {dishId} not found.");
        return NoContent();
    }
}