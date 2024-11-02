namespace FoodSuit_Backend.Orders.Domain.Model.Commands;

public record CreateOrderCommand(
    string Table,
    string Status,
    /*string DishName,
    string Amount,
    string WaiterFirstName, 
    string WaiterLastName,*/
    DateTime Date, 
    string Total);