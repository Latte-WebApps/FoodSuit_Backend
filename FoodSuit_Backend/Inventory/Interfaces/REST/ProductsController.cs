using System.Net.Mime;
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
[SwaggerTag("Available Product Endpoints.")]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService) : ControllerBase
{
    /// <summary>
    /// Create a new product.
    /// </summary>
    /// <param name="resource">The <see cref="CreateProductResource"/> resource.</param>
    /// <returns>The created product.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product",
        Description = "Create a new product in the inventory",
        OperationId = "CreateProduct")]
    [SwaggerResponse(StatusCodes.Status201Created, "The product was created", typeof(ProductResource))]
    public async Task<IActionResult> CreateProduct(CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, productResource);
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="resource">The <see cref="UpdateProductResource"/> resource.</param>
    /// <returns>The updated product.</returns>
    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Update an existing product",
        Description = "Update an existing product in the inventory",
        OperationId = "UpdateProduct")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was updated", typeof(ProductResource))]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductResource resource)
    {
        if (id <= 0 || resource is null) 
            return BadRequest("Invalid ID or resource is null.");

        try
        {
            var updateProductCommand = UpdateItemCommandFromResourceAssembler.ToCommandFromResource(resource);
            var product = await productCommandService.Handle(id, updateProductCommand);

            if (product == null)
                return NotFound($"Product not found with id: {id}");

            var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
            return Ok(productResource);
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
    [SwaggerOperation(
        Summary = "Get all products",
        Description = "Get all products in the inventory",
        OperationId = "GetAllProducts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The products were found", typeof(IEnumerable<ProductResource>))]
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
    [SwaggerOperation(
        Summary = "Get product by ID",
        Description = "Get a product by its ID",
        OperationId = "GetProductById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was found", typeof(ProductResource))]
    public async Task<IActionResult> GetProductById(int id)
    {
        var getProductByIdQuery = new GetProductByIdQuery(id);
        var result = await productQueryService.Handle(getProductByIdQuery);
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Delete a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>A message indicating whether the deletion was successful.</returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Delete a product by ID",
        Description = "Delete a product from the inventory by its ID",
        OperationId = "DeleteProduct")]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The product was not found")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var deleteProductCommand = new DeleteProductCommand(id);
            var productDeleted = await productCommandService.Handle(deleteProductCommand);

            if (productDeleted is null)
                return NotFound($"Product with id {id} not found.");

            return Ok("Product deleted successfully!");
        }
        catch (ItemNotFoundException)
        {
            return NotFound($"Product with id {id} not found.");
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}