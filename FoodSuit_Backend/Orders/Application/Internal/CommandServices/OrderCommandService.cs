using FoodSuit_Backend.Orders.Domain.Model.Aggregates;
using FoodSuit_Backend.Orders.Domain.Model.Commands;
using FoodSuit_Backend.Orders.Domain.Repositories;
using FoodSuit_Backend.Orders.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Orders.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
: IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        var order = new Order(command);
        try
        {
            await orderRepository.AddAsync(order);
            await unitOfWork.CompleteAsync();
            return order;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the dish: {e.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteOrderByIdAsync(DeleteOrderCommand command)
    {
        try
        {
            var order = await orderRepository.FindOrderByIdAsync(command.Id);
            if (order == null)
            {
                Console.WriteLine($"Order with ID {command.Id} not found.");
                return false;
            }
            orderRepository.Remove(order);
            await unitOfWork.CompleteAsync();
            Console.WriteLine($"Order with ID {command.Id} deleted successfully.");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the order: {e.Message}");
            return false;
        }
    }
}