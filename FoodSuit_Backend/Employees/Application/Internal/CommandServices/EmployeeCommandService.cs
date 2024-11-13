using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Employees.Application.Internal.CommandServices;

public class EmployeeCommandService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    : IEmployeeCommandService
{
    public async Task<Employee?> Handle(CreateEmployeeCommand command)
    {
        var employee = new Employee(command);
        try
        {
            await employeeRepository.AddAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Employee?> Handle(int id, UpdateEmployeeCommand command)
    {
        var employee = await employeeRepository.FindByIdAsync(id);

        if (employee == null)
        {
            return null;
        }

        employee.UpdateEmployee(
            command.FirstName,
            command.LastName,
            command.EntryHour,
            command.EntryMinute,
            command.ExitHour,
            command.ExitMinute
        );
        try
        {
            await unitOfWork.UpdateAsync(employee);
            await unitOfWork.CompleteAsync();

            return employee;
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating employee", ex);
        }
    }

    public async Task<bool?> Handle(DeleteEmployeeCommand command)
    {
        var employee = await employeeRepository.FindByIdAsync(command.id);

        if (employee == null)
        {
            return false;
        }

        try
        {
            await unitOfWork.RemoveAsync(employee);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception)
        {
            return null;
        }
    }
}