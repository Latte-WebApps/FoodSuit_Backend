using FoodSuit_Backend.Employees.Domain.Model.Aggregates;
using FoodSuit_Backend.Employees.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Employees.Interfaces.REST.Transform
{
    public class EmployeeResourceFromEntityAssembler
    {
        public static EmployeeResource ToResourceFromEntity(Employee entity)
        {
            return new EmployeeResource(entity.Id, entity.FullName, entity.EntryTime, entity.ExitTime);
        }
    }
}