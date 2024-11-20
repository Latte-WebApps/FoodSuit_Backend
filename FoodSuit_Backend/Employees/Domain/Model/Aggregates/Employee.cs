using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Employees.Domain.Model.Aggregates;

/// <summary>
/// This is the Aggregate class for the Employee Endpoint, it stores its attributes, and methods
/// </summary>
public partial class Employee
{
    public int Id { get; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string EntryTime { get; private set; } = string.Empty; // Formato "HH:mm"
    public string ExitTime { get; private set; } = string.Empty;  // Formato "HH:mm"

    public string FullName => $"{FirstName} {LastName}";

    public Employee() {}

    public Employee(string firstName, string lastName, string entryTime, string exitTime)
    {
        FirstName = firstName;
        LastName = lastName;
        EntryTime = entryTime;
        ExitTime = exitTime;
    }

    public Employee(CreateEmployeeCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        EntryTime = command.EntryTime;
        ExitTime = command.ExitTime;
    }

    public void UpdateEmployee(string firstName, string lastName, string entryTime, string exitTime)
    {
        FirstName = firstName;
        LastName = lastName;
        EntryTime = entryTime;
        ExitTime = exitTime;
    }
}

