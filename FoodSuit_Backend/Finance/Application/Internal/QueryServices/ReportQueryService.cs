using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Model.Queries;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Finance.Domain.Services;

namespace FoodSuit_Backend.Finance.Application.Internal.QueryServices;

/// <summary>
/// Report query service
/// </summary>
/// <param name="reportRepository">
/// The report repository
/// </param>
public class ReportQueryService(IReportRepository reportRepository)
: IReportQueryService
{
    /// <inheritdoc />
    public async Task<Report?> Handle(GetReportByIdQuery query)
    {
        return await reportRepository.FindByIdAsync(query.ReportId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery query)
    {
        return await reportRepository.ListAsync();
    }
}