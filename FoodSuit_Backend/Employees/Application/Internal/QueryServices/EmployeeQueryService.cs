using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Queries;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Employees.Application.Internal.QueryServices;

public class EmployeeQueryService (IEmployeeRepository employeeRepository) : IEmployeeQueryService
{
    public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query)
    {
        return await employeeRepository.ListAsync();
    }

    public async Task<Employee?> Handle(GetEmployeeByIdQuery query)
    {
        return await employeeRepository.FindByIdAsync(query.EmployeeId);
    }
}