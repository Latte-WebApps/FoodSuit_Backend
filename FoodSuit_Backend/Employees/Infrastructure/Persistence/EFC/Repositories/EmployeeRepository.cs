using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodSuit_Backend.Employees.Infrastructure.Persistence.EFC.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public async Task<Employee?> GetByUsernameAsync(string firstName, string lastName)
    {
        return await Context.Set<Employee>()
            .FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName);
    }
}