using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Dishes.Domain.Model.Aggregates;

public partial class Dish
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public string Price { get; private set; }
    
    public string Category { get; private set; }
    public string Instruction { get; private set; }
    
    public List<ProductId> ProductId { get; private set; }


    protected Dish()
    {
        Name = string.Empty;
        Category = string.Empty;
        Price = string.Empty;
        Instruction = string.Empty;
        ProductId = new List<ProductId>();
    }
    
    public Dish(CreateDishCommand command)
    {
        Name = command.Name;
        Category = command.Category;
        Price = command.Price;
        Instruction = command.Instruction;
        ProductId = command.ProductId;
    }
}