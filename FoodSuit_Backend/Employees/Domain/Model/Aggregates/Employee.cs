using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Employees.Domain.Model.Aggregates;

public partial  class Employee
{
    public int Id { get; }
    public EmployeeName Name { get; private set; }
    public EntryTime EntryTime { get; private set; }
    public ExitTime ExitTime { get; private set; }
    
    public string EmployeeNameString => Name.FullName;
    public string EntryTimeString => EntryTime.ToString();
    public string ExitTimeString => ExitTime.ToString();

    public Employee()
    {
        Name = new EmployeeName();
        EntryTime = new EntryTime();
        ExitTime = new ExitTime();
    }

    public Employee(string firstName, string lastName, int entryHour, int entryMinute, int exitHour, int exitMinute)
    {
        Name = new EmployeeName(firstName, lastName);
        EntryTime = new EntryTime(entryHour, entryMinute);
        ExitTime = new ExitTime(exitHour, exitMinute);
    }

    public Employee(CreateEmployeeCommand command)
    {
        Name = new EmployeeName(command.FirstName, command.LastName);
        EntryTime = new EntryTime(command.EntryHour, command.EntryMinute);
        ExitTime = new ExitTime(command.ExitHour, command.ExitMinute);  
    }
}