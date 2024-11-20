using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Employees.Interfaces.REST.Transform
{
    public static class CreateEmployeeCommandFromResourceAssembler
    {
        public static CreateEmployeeCommand ToCommandFromResource(CreateEmployeeResource resource)
        {
            return new CreateEmployeeCommand(
                resource.FirstName,
                resource.LastName,
                resource.EntryTime, // Ahora solo es un string "HH:mm"
                resource.ExitTime   // Ahora solo es un string "HH:mm"
            );
        }
    }
}