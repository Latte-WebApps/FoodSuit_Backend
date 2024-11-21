namespace FoodSuit_Backend.Employees.Domain.Model.Commands;

public record UpdateEmployeeCommand(
    string FirstName, 
    string LastName, 
    string EntryTime,  // Cambiado a string
    string ExitTime    // Cambiado a string
);