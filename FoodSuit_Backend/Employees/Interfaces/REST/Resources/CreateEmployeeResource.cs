namespace FoodSuit_Backend.Employees.Interfaces.REST.Resources;

public record CreateEmployeeResource(string FirstName, string LastName, string EntryTime, string ExitTime);