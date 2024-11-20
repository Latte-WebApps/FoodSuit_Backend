﻿using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Employees.Domain.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee?> GetByUsernameAsync(string firstName, string lastName);
}