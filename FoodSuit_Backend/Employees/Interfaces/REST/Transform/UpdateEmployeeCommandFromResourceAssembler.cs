using FoodSuit_Backend.Employees.Domain.Model.Commands;

namespace FoodSuit_Backend.Employees.Interfaces.REST.Transform;

public class UpdateEmployeeCommandFromResourceAssembler
{
    public static UpdateEmployeeCommand ToCommandFromResource(UpdateEmployeeResource resource)
    {
        return new UpdateEmployeeCommand(
            resource.FirstName,
            resource.LastName,
            resource.EntryHour,
            resource.EntryMinute,
            resource.ExitHour,
            resource.ExitMinute);
    }
}