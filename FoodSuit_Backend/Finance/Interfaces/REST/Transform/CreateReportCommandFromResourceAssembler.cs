using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;
using FoodSuit_Backend.Finance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Finance.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert a CreateReportResource to a CreateReportCommand.
/// </summary>
public static class CreateReportCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a CreateReportResource to a CreateReportCommand.
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateReportResource"/> resource to create the command from
    /// </param>
    /// <returns>
    /// The <see cref="CreateReportCommand"/> command created from the resource
    /// </returns>
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource)
    {
        var parsedReportType = Enum.Parse<EReportType>(resource.ReportType, true);
        return new CreateReportCommand(resource.Description, parsedReportType, resource.Date, resource.Amount, resource.OrdersId, resource.ProductsId);
    }
}