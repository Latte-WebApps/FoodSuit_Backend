using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Commands;

namespace FoodSuit_Backend.Employees.Domain.Services;

public interface IEmployeeCommandService
{
    Task<Employee?> Handle(CreateEmployeeCommand command);
    Task<Employee?> Handle(int id, UpdateEmployeeCommand command);
    Task<bool?> Handle(DeleteEmployeeCommand command);

}