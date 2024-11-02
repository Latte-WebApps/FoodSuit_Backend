﻿using System.Net.Mime;
using FoodSuit_Backend.Inventory.Domain.exceptions;
using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Inventory.Domain.Model.Queries;
using FoodSuit_Backend.Inventory.Domain.Services;
using FoodSuit_Backend.Inventory.Interfaces.Rest.Resources;
using FoodSuit_Backend.Inventory.Interfaces.Rest.Transform;
using FoodSuit_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodSuit_Backend.Inventory.Interfaces.REST;

/// <summary>
/// Controller for managing products in the inventory.
/// </summary>
[ApiController]
[Route("/api/v1/[Controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService) : ControllerBase
{
    /// <summary>
    /// Create a new item.
    /// </summary>
    /// <param name="resource">The <see cref="CreateProductResource"/> resource.</param>
    /// <returns>The created item.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new item",
        Description = "Create a new item in the inventory",
        OperationId = "CreateItem")]
    [SwaggerResponse(StatusCodes.Status201Created, "The item was created", typeof(ProductResource))]
    public async Task<IActionResult> CreateItem(CreateProductResource resource)
    {
        var createItemCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var item = await productCommandService.Handle(createItemCommand);
        if (item is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(item);
        return CreatedAtAction(nameof(GetProductById), new { id = item.Id }, productResource);
    }

    /// <summary>
    /// Update an existing item.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="resource">The <see cref="UpdateProductResource"/> resource.</param>
    /// <returns>The updated item.</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateItem(int id, UpdateProductResource resource)
    {
        if (id <= 0 || resource is null) 
            return BadRequest("Invalid ID or resource is null.");

        try
        {
            var updateItemCommand = UpdateItemCommandFromResourceAssembler.ToCommandFromResource(resource);
            var item = await productCommandService.Handle(id, updateItemCommand);

            if (item == null)
                return NotFound($"Item not found with id: {id}");

            var itemResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(item);
            return Ok(itemResource);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProfilesQuery = new GetAllProductQuery();
        var profiles = await productQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }

    /// <summary>
    /// Get a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>The product with the specified ID.</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var getItemByIdQuery = new GetProductByIdQuery(id);
        var result = await productQueryService.Handle(getItemByIdQuery);
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Delete a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>A message indicating whether the deletion was successful.</returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var deleteItemCommand = new DeleteProductCommand(id);
            var itemDeleted = await productCommandService.Handle(deleteItemCommand);

            if (itemDeleted is null)
                return NotFound($"Item with id {id} not found.");

            return Ok("Product deleted successfully!");
        }
        catch (ItemNotFoundException)
        {
            return NotFound($"Item with id {id} not found.");
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}