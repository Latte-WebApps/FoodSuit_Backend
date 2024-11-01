using FoodSuit_Backend.Orders.Domain.Model.Commands;

namespace FoodSuit_Backend.Orders.Domain.Model.Aggregates;

public partial class Order
{
    
    public int Id { get; }
    public DateTime Date { get; private set; }
    public string Table { get; private set; }
    public string Status { get; private set; }
    //public OrderDishes Dishes { get; private set; }
    //public WaiterName Name { get; private set; }
    public string Total { get; private set; }
    
    //public string FullName => Name.FullName;
    

    protected Order()
    {
        Table = string.Empty;
        Status = string.Empty;
        //Dishes = new OrderDishes();
        //Name = new WaiterName();
        Total = string.Empty;
        Date = DateTime.Now;
    }
    
    public Order(CreateOrderCommand command)
    {
        Table = command.Table;
        Status = command.Status;
        Total = command.Total;
        Date = DateTime.Now;
    }
}