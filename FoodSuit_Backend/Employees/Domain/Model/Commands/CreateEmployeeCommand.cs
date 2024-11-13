namespace FoodSuit_Backend.Employees.Domain.Model.Commands;

public record CreateEmployeeCommand(
    string FirstName, 
    string LastName, 
    int EntryHour, 
    int EntryMinute, 
    int ExitHour, 
    int ExitMinute);