using FoodSuit_Backend.Inventory.Domain.Model.Aggregates;
using FoodSuit_Backend.Inventory.Domain.Model.Commands;

namespace FoodSuit_Backend.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
    Task<Product?> Handle(int id, UpdateProductCommand command);
    Task<bool?> Handle(DeleteProductCommand command);
    
}