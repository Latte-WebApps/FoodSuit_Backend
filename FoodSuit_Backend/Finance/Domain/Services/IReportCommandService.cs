using FoodSuit_Backend.Finance.Domain.Model.Commands;
using FoodSuit_Backend.Finance.Domain.Model.Entities;

namespace FoodSuit_Backend.Finance.Domain.Services;

/// <summary>
/// Report command service interface.
/// </summary>
public interface IReportCommandService
{
    /// <summary>
    /// Handle create report command.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateReportCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Report"/> entity
    /// </returns>
    Task<Report?> Handle(CreateReportCommand command);
}