using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.Entities;

namespace FoodSuit_Backend.Finance.Domain.Services;

public interface IReportCommandService
{
    Task<Report?> Handle(CreateReportCommand command);
}