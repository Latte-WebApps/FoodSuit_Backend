using FoodSuit_Backend.Dishes.Domain.Model.Commands;

namespace FoodSuit_Backend.Dishes.Domain.Model.Aggregates;

public partial class Dish
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public string Price { get; private set; }
    
    public string Category { get; private set; }


    protected Dish()
    {
        Name = string.Empty;
        Category = string.Empty;
        Price = string.Empty;
    }
    
    public Dish(CreateDishCommand command)
    {
        Name = command.Name;
        Category = command.Category;
        Price = command.Price;
    }
}