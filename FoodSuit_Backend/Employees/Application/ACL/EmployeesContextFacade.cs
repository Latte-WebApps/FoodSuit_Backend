using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Employees.Interfaces.ACL;

namespace FoodSuit_Backend.Employees.Application.ACL
{
    public class EmployeesContextFacade(IEmployeeCommandService employeeCommandService, IEmployeeQueryService employeeQueryService) : IEmployeesContextFacade
    {
        public async Task<int> CreateEmployee(string firstName, string lastName, string entryTime, string exitTime)
        {
            var createEmployeeCommand = new CreateEmployeeCommand(firstName, lastName, entryTime, exitTime);
            var employee = await employeeCommandService.Handle(createEmployeeCommand);
            return employee?.Id ?? 0;
        }
    }
}