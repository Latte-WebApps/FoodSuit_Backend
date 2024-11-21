namespace FoodSuit_Backend.Finance.Domain.Model.Queries;

/// <summary>
/// Get Report By Id Query
/// </summary>
/// <param name="ReportId">
/// Id of the report to get
/// </param>
public record GetReportByIdQuery(int ReportId);