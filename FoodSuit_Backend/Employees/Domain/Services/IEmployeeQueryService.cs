using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Queries;

namespace FoodSuit_Backend.Employees.Domain.Services;

public interface IEmployeeQueryService
{
    Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query);
    
    Task<Employee?> Handle(GetEmployeeByIdQuery query);
}