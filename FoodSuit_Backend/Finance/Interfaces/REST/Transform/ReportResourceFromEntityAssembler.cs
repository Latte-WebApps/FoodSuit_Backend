using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Finance.Interfaces.REST.Transform;

public static class ReportResourceFromEntityAssembler
{
    public static ReportResource ToResourceFromEntity(Report entity)
    {
        return new ReportResource(entity.Id, entity.Description, entity.Type.ToString());
    }
}