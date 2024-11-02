using System.Net.Mime;
using FoodSuit_Backend.Orders.Domain.Model.Commands;
using FoodSuit_Backend.Orders.Domain.Model.Queries;
using FoodSuit_Backend.Orders.Domain.Services;
using FoodSuit_Backend.Orders.Interfaces.REST.Resources;
using FoodSuit_Backend.Orders.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FoodSuit_Backend.Orders.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class OrdersController(IOrderCommandService orderCommandService,
    IOrderQueryService orderQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await orderCommandService.Handle(createOrderCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetOrderById), new { orderId = result.Id },
            OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult> GetOrderById(int orderId)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(orderId);
        var result = await orderQueryService.Handle(getOrderByIdQuery);
        if (result is null) return NotFound();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(orderResource);
    }

    [HttpDelete("{orderId}")]
    public async Task<ActionResult> DeleteOrderById(int orderId)
    {
        var deleteOrderCommand = new DeleteOrderCommand(orderId);
        var result = await orderCommandService.DeleteOrderByIdAsync(deleteOrderCommand);
        if (!result) return NotFound($"Order with ID {orderId} not found.");
        return NoContent();
    }
}