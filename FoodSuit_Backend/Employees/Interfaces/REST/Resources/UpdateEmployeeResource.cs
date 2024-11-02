namespace FoodSuit_Backend.Employees.Interfaces.REST.Transform;

public record UpdateEmployeeResource(string FirstName, string LastName, int EntryHour, int EntryMinute, int ExitHour, int ExitMinute);