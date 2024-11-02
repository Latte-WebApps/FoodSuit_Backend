using System.Net.Mime;
using FoodSuit_Backend.Orders.Domain.Model.Commands;
using FoodSuit_Backend.Orders.Domain.Model.Queries;
using FoodSuit_Backend.Orders.Domain.Services;
using FoodSuit_Backend.Orders.Interfaces.REST.Resources;
using FoodSuit_Backend.Orders.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodSuit_Backend.Orders.Interfaces.REST;

/// <summary>
/// Controller for managing orders.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Order Endpoints.")]
public class OrdersController(IOrderCommandService orderCommandService,
    IOrderQueryService orderQueryService) : ControllerBase
{
    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="resource">The resource containing the order details.</param>
    /// <returns>A newly created order.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new order",
        Description = "Create a new order in the system",
        OperationId = "CreateOrder")]
    [SwaggerResponse(StatusCodes.Status201Created, "The order was created", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data")]
    public async Task<ActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await orderCommandService.Handle(createOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrderById), new { orderId = result.Id },
            OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Gets an order by its ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to retrieve.</param>
    /// <returns>The order with the specified ID.</returns>
    [HttpGet("{orderId}")]
    [SwaggerOperation(
        Summary = "Get order by ID",
        Description = "Get an order by its ID",
        OperationId = "GetOrderById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The order was found", typeof(OrderResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]
    public async Task<ActionResult> GetOrderById(int orderId)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(orderId);
        var result = await orderQueryService.Handle(getOrderByIdQuery);
        if (result is null) return NotFound();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(orderResource);
    }

    /// <summary>
    /// Deletes an order by its ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to delete.</param>
    /// <returns>A message indicating whether the deletion was successful.</returns>
    [HttpDelete("{orderId}")]
    [SwaggerOperation(
        Summary = "Delete order by ID",
        Description = "Delete an order from the system by its ID",
        OperationId = "DeleteOrderById")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The order was deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order was not found")]
    public async Task<ActionResult> DeleteOrderById(int orderId)
    {
        var deleteOrderCommand = new DeleteOrderCommand(orderId);
        var result = await orderCommandService.DeleteOrderByIdAsync(deleteOrderCommand);
        if (!result) return NotFound($"Order with ID {orderId} not found.");
        return NoContent();
    }
}
