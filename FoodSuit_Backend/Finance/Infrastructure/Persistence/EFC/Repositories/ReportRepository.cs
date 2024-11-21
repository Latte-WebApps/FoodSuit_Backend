using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FoodSuit_Backend.Finance.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Report Repository implementation
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class ReportRepository(AppDbContext context) : BaseRepository<Report>(context), IReportRepository;