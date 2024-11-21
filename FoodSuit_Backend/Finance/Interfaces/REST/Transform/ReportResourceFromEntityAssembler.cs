using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Finance.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert a Report entity to a Report resource.
/// </summary>
public static class ReportResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a Report entity to a Report resource.
    /// </summary>
    /// <param name="entity">
    /// <see cref="Report"/> entity to convert.
    /// </param>
    /// <returns>
    /// <see cref="ReportResource"/> converted from <see cref="Report"/> entity.
    /// </returns>
    public static ReportResource ToResourceFromEntity(Report entity)
    {
        return new ReportResource(entity.Id, entity.Description, entity.Type.ToString(), entity.Date, entity.Amount, entity.OrdersId, entity.ProductsId);
    }
}