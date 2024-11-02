using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Employees.Interfaces.ACL;

namespace FoodSuit_Backend.Employees.Application.ACL;

public class EmployeesContextFacade(IEmployeeCommandService employeeCommandService, IEmployeeQueryService employeeQueryService) : IEmployeesContextFacade
{
    public async Task<int> CreateEmployee(string firstName, string lastName, int entryHour, int entryMinute, int exitHour, int exitMinute)
    {
        var createEmployeeCommand = new CreateEmployeeCommand(firstName, lastName, entryHour, entryMinute, exitHour, exitMinute);
        var employee = await employeeCommandService.Handle(createEmployeeCommand);
        return employee?.Id ?? 0;
    }
    
}