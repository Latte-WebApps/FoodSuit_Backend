using FoodSuit_Backend.Dishes.Domain.Model.Commands;
using FoodSuit_Backend.Dishes.Domain.Model.Entities;

namespace FoodSuit_Backend.Dishes.Domain.Model.Aggregates;

public partial class Dish
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public string Price { get; private set; }
    
    public string Category { get; private set; }
    public string Instruction { get; private set; }
    
    public List<Products> Products { get; private set; }


    protected Dish()
    {
        Name = string.Empty;
        Category = string.Empty;
        Price = string.Empty;
        Instruction = string.Empty;
        Products = new List<Products>();
    }
    
    public Dish(CreateDishCommand command)
    {
        Name = command.Name;
        Category = command.Category;
        Price = command.Price;
        Instruction = command.Instruction;
        Products = command.Products;
    }
}