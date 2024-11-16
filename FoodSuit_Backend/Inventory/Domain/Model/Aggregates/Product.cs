using FoodSuit_Backend.Inventory.Domain.Model.Commands;
using FoodSuit_Backend.Inventory.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Inventory.Domain.Model.Aggregates;


/// Item Aggregate
/// <summary>
/// This class represents the Item aggregate. It is used to store the ingredientes.
/// </summary>
///
public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public string ImageUrl { get; private set; }
    public float Price  { get; private set; }



    protected Product()
    {
        this.Name = string.Empty;
        this.Quantity = 0 ;
        this.ImageUrl = string.Empty;
        this.Price = 0;
    }


    /// <summary>
    /// Constructor for the Inventory aggregate
    /// </summary>
    /// <remarks>
    /// The constructor is the command handler for the CreateItemCommand. It initializes the Item aggregate
    /// </remarks>
    /// <param name="command">The CreateFavoriteSourceCommand command</param>


    public Product(CreateProductCommand command)
    {
        this.Name = command.Name;
        this.Quantity = command.Quantity;
        this.ImageUrl = command.Image;
        this.Price = command.Price;
    }


    /// <remarks>
    /// The constructor is the command handler for the UpdateItemCommand. It updates item aggregate
    /// </remarks>
    /// <param name="command">The UpdateFavoriteSourceCommand command</param>

    public Product(UpdateProductCommand command)
    {
        this.Name = command.Name;
        this.Quantity = command.Quantity;
        this.ImageUrl = command.ImageUrl;
        this.Price = command.Price;
    }

    public void UpdateInformation(string name, int quantity, string image, float price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty or whitespace.");

        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.");

        Name = name;
        Quantity = 0;
        ImageUrl = image;
        Price = price;
    }

}
