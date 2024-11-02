using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Model.ValueObjects;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FoodSuit_Backend.Employees.Infrastructure.Persistence.EFC.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public async Task<Employee?> GetByUsernameAsync(EmployeeName name)
    {
        return Context.Set<Employee>().FirstOrDefault(e => e.Name == name);
    }
}