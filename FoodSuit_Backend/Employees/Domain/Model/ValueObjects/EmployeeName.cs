namespace FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

public record EmployeeName(string FirstName, string LastName)
{
    public EmployeeName() : this(string.Empty, string.Empty){}
    public EmployeeName(string firstName) : this(firstName, string.Empty) { }
    public string FullName => $"{FirstName} {LastName}";
}