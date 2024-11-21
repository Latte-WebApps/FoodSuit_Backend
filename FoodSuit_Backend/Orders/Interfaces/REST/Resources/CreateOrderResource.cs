namespace FoodSuit_Backend.Orders.Interfaces.REST.Resources;

public record CreateOrderResource(
    int Id,
    string Table,
    string Status,
    /*string DishName,
    string Amount,
    string WaiterName,
    string WaiterLastName,*/
    DateTime Date, 
    string Total);