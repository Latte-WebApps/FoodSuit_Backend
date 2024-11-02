using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Finance.Domain.Services;
using FoodSuit_Backend.Shared.Domain.Repositories;

namespace FoodSuit_Backend.Finance.Application.Internal.CommandServices;

public class ReportCommandService (IReportRepository reportRepository, IUnitOfWork unitOfWork)
: IReportCommandService
{
    
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        var report = new Report(command.ReportType)
        {
            Description = command.Description
        };
        await reportRepository.AddAsync(report);
        await unitOfWork.CompleteAsync();
        return report;
    }
}