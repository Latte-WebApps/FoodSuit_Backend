using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Model.Queries;

namespace FoodSuit_Backend.Finance.Domain.Services;

/// <summary>
/// Report query service interface.
/// </summary>
public interface IReportQueryService
{
    /// <summary>
    /// Handle get all reports query.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllReportsQuery"/> query
    /// </param>
    /// <returns>
    /// A list of <see cref="Report"/>
    /// </returns>
    Task<IEnumerable<Report>> Handle(GetAllReportsQuery query);
    
    /// <summary>
    /// Handle get report by id query.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetReportByIdQuery"/> query
    /// </param>
    /// <returns>
    /// A <see cref="Report"/> entity or null
    /// </returns>
    Task<Report?> Handle(GetReportByIdQuery query);
}