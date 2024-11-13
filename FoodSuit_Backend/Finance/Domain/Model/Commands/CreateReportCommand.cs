using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Finance.Domain.Model.Commands;

/// <summary>
/// Create Report Command
/// </summary>
/// <param name="Description">
/// Description of the report
/// </param>
/// <param name="ReportType">
/// Type of the report
/// </param>
/// <param name="Date">
/// Date of the report
/// </param>
/// <param name="Amount">
/// Monetary amount of the report
/// </param>
/// <param name="OrdersId">
/// Orders Id, if report is an order
/// </param>
/// <param name="ProductsId">
/// Products Id, if report is a product
/// </param>
public record CreateReportCommand(string Description, EReportType ReportType, string Date, int Amount, int OrdersId, int ProductsId);