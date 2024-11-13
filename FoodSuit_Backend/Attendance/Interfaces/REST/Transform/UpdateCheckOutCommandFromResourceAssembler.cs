using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Attendance.Interfaces.REST.Transform;

public static class UpdateCheckOutCommandFromResourceAssembler
{
    public static UpdateCheckOutCommand ToCommandFromResource(int id, UpdateCheckOutResource resource)
    {
        return new UpdateCheckOutCommand(resource.EmployeeId, resource.CheckOutTime);
    }
}