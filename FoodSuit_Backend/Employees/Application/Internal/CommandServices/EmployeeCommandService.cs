using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Employees.Application.Internal.CommandServices;

public class EmployeeCommandService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork) : IEmployeeCommandService
{
    
}