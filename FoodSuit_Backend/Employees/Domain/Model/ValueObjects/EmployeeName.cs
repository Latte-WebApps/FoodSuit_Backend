namespace FoodSuit_Backend.Employees.Domain.Model.ValueObjects;

public record EmployeeName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public EmployeeName(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    // Constructor sin parámetros para inicializar con valores predeterminados
    public EmployeeName() : this("DefaultFirstName", "DefaultLastName") { }

    public string FullName => $"{FirstName} {LastName}";
}
