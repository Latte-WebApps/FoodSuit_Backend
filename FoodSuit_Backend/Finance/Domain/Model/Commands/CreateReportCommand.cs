using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Finance.Domain.Model.Commands;

public record CreateReportCommand(string Description, EReportType ReportType, string Date, int Amount, int OrdersId, int ProductsId);