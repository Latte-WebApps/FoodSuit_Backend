using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;
using FoodSuit_Backend.Finance.Interfaces.REST.Resources;

namespace FoodSuit_Backend.Finance.Interfaces.REST.Transform;

public static class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource)
    {
        var parsedReportType = Enum.Parse<EReportType>(resource.ReportType, true);
        return new CreateReportCommand(resource.Description, parsedReportType);
    }
}