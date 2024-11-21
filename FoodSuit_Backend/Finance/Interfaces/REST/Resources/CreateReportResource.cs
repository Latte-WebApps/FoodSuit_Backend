namespace FoodSuit_Backend.Finance.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a report
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
/// Amount of the report
/// </param>
/// <param name="OrdersId">
/// Id of the order, if report is related to an order
/// </param>
/// <param name="ProductsId">
/// Id of the product, if report is related to a product
/// </param>
public record CreateReportResource(string Description, string ReportType, string Date, int Amount, int OrdersId, int ProductsId);