using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Queries;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;

namespace FoodSuit_Backend.Employees.Application.Internal.QueryServices;
/// <summary>
///This class is the service for all the queries of the Employee Endpoint, it lists all Employees registered and finds a single Employee by its ID
/// </summary>
/// <param name="employeeRepository"></param>
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