using System.Net.Mime;
using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Domain.Model.Queries;
using FoodSuit_Backend.Dishes.Domain.Services;
using FoodSuit_Backend.Dishes.Interfaces.REST.Resources;
using FoodSuit_Backend.Dishes.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodSuit_Backend.Dishes.Interfaces.REST;



/// <summary>
/// Controller for managing dishes.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Dish Endpoints.")]
public class DishesController( 
    IDishCommandService dishCommandService,
    IDishQueryService dishQueryService
) : ControllerBase
{
    /// <summary>
    /// Create a new dish.
    /// </summary>
    /// <param name="resource">The <see cref="CreateDishResource"/> to create a new dish from.</param>
    /// <returns>The <see cref="DishResource"/> dish if created, otherwise a <see cref="BadRequestResult"/>.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new dish",
        Description = "Create a new dish in the system",
        OperationId = "CreateDish")]
    [SwaggerResponse(StatusCodes.Status201Created, "The dish was successfully created", typeof(DishResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The dish could not be created")]
    public async Task<IActionResult> CreateDish([FromBody] CreateDishResource resource)
    {
        var createDishCommand = CreateDishCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await dishCommandService.Handle(createDishCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetDishById), new {id = result.Id}, DishResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Get a dish by ID.
    /// </summary>
    /// <param name="id">The ID of the dish to retrieve.</param>
    /// <returns>The dish with the specified ID.</returns>
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get dish by ID",
        Description = "Get a dish by its ID",
        OperationId = "GetDishById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The dish was found", typeof(DishResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The dish was not found")]
    public async Task<ActionResult> GetDishById(int id)
    {
        var getDishByIdQuery = new GetDishByIdQuery(id);
        var result = await dishQueryService.Handle(getDishByIdQuery);
        if (result is null) return NotFound();
        var resource = DishResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    /// <summary>
    /// Get all dishes.
    /// </summary>
    /// <returns>
    /// A list of all dishes in the system.
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all dishes", 
        Description = "Get all dishes in the system", 
        OperationId = "GetAllDishes")]
    [SwaggerResponse(200, "The dishes were found", typeof(IEnumerable<DishResource>))]
    [SwaggerResponse(404, "No dishes were found")]
    public async Task<IActionResult> GetAllDishes()
    {
        var getAllDishesQuery = new GetAllDishesQuery();
        var dishes = await dishQueryService.Handle(getAllDishesQuery);
        var dishResources = dishes.Select(DishResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(dishResources);
    }

    /// <summary>
    /// Get all dishes by category.
    /// </summary>
    /// <param name="category">The category of the dishes to retrieve.</param>
    /// <returns>A list of dishes in the specified category.</returns>
    [HttpGet("category/{category}")]
    [SwaggerOperation(
        Summary = "Get all dishes by category",
        Description = "Get all dishes in the specified category",
        OperationId = "GetAllDishesByCategory")]
    [SwaggerResponse(StatusCodes.Status200OK, "The dishes were found", typeof(IEnumerable<DishResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No dishes were found in the specified category")]
    private async Task<ActionResult> GetAllDishesByCategory(string category)
    {
        var getAllDishesByCategoryQuery = new GetAllDishesByCategoryQuery(category);
        var result = await dishQueryService.Handle(getAllDishesByCategoryQuery);
        if (result is null) return NotFound();
        var resource = result.Select(DishResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    /// <summary>
    /// Delete a dish by ID.
    /// </summary>
    /// <param name="dishId">The ID of the dish to delete.</param>
    /// <returns>A message indicating whether the deletion was successful.</returns>
    [HttpDelete("{dishId:int}")]
    [SwaggerOperation(
        Summary = "Delete dish by ID",
        Description = "Delete a dish from the system by its ID",
        OperationId = "DeleteDishById")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The dish was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The dish was not found")]
    public async Task<IActionResult> DeleteDish(int dishId)
    {
        var deleteCommand = new DeleteDishCommand(dishId);
        var result = await dishCommandService.DeleteDishByIdAsync(deleteCommand);
        if (!result) return NotFound($"Dish with id {dishId} not found.");
        return NoContent();
    }
}