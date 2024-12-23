﻿using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Employees.Application.Internal.CommandServices;

/// <summary>
///This class is the service for all the commands of the Employee Endpoint, it handles Create, Update and Delete
/// </summary>
/// <param name="employeeRepository"></param>
/// <param name="unitOfWork"></param>

public class EmployeeCommandService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    : IEmployeeCommandService
{
    public async Task<Employee?> Handle(CreateEmployeeCommand command)
    {
        var employee = new Employee(command.FirstName, command.LastName, command.EntryTime, command.ExitTime);
        try
        {
            await employeeRepository.AddAsync(employee);
            await unitOfWork.CompleteAsync();
            return employee;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating employee", ex);
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
            command.EntryTime,
            command.ExitTime
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