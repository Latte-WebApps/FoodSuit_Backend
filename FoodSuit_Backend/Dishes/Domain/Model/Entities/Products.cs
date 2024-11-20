namespace FoodSuit_Backend.Dishes.Domain.Model.Entities;

public class Products
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public Products(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }

    public Products(int id)
    {
    }

}