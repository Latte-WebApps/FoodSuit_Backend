﻿namespace FoodSuit_Backend.Employees.Interfaces.ACL
{
    public interface IEmployeesContextFacade
    {
        Task<int> CreateEmployee(string firstName, string lastName, string entryTime, string exitTime);
    }
}