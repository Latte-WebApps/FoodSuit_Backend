using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Finance.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Finance.Application.Internal.CommandServices;

/// <summary>
/// Report command service
/// </summary>
/// <param name="reportRepository">
/// The report repository
/// </param>
/// <param name="unitOfWork">
/// The unit of work
/// </param>
public class ReportCommandService (IReportRepository reportRepository, IUnitOfWork unitOfWork)
: IReportCommandService
{
    /// <inheritdoc />
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        var report = new Report(command.ReportType)
        {
            Description = command.Description,
            Date = command.Date,
            Amount = command.Amount,
            OrdersId = command.OrdersId,
            ProductsId = command.ProductsId
        };
        await reportRepository.AddAsync(report);
        await unitOfWork.CompleteAsync();
        return report;
    }
}