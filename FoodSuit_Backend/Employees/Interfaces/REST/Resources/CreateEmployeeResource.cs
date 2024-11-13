namespace FoodSuit_Backend.Employees.Interfaces.REST.Resources;

public record CreateEmployeeResource (string FirstName, string LastName, int EntryHour, int EntryMinute, int ExitHour, int ExitMinute);