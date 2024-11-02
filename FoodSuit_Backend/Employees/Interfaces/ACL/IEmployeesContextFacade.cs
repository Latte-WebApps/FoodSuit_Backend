namespace FoodSuit_Backend.Employees.Interfaces.ACL;

public interface IEmployeesContextFacade
{
    Task<int>CreateEmployee(string firstName, string lastName, int entryHour, int entryMinute, int exitHour, int exitMinute);
}