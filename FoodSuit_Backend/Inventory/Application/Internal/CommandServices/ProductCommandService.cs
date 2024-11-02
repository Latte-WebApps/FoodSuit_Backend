using FoodSuit_Backend.Inventory.Domain.exceptions;
using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Inventory.Domain.Repositories;
using FoodSuit_Backend.Inventory.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            throw new Exception("Failed to create item", e);
        }
    }


    public async Task<Product?> Handle(int id, UpdateProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(id);

        if (product == null) {throw new Exception($"Item not found with id: {id}");}
        
        product.UpdateInformation(command.Name, command.Quantity, command.ImageUrl, command.Price);
        
        try
        {
            await productRepository.UpdateAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating item: {e.Message}");
            Console.WriteLine($"StackTrace: {e.StackTrace}");
            throw new Exception("Failed to update item", e);
        }
    }

    public async Task<bool?> Handle(DeleteProductCommand command)
    {
        var item = await productRepository.FindByIdAsync(command.Id);
        if (item == null) { throw new ItemNotFoundException("Item not found"); }


        try
        {
            productRepository.Remove(item);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Failed to delete item", e);
        }
    }
}