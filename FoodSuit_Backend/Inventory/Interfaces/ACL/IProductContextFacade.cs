namespace FoodSuit_Backend.Inventory.Interfaces.ACL;

public interface IProductContextFacade
{
    Task<int> FetchProductIdByName(string name);
}