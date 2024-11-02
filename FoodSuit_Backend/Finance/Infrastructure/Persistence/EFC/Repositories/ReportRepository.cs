using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FoodSuit_Backend.Finance.Infrastructure.Persistence.EFC.Repositories;

public class ReportRepository(AppDbContext context) : BaseRepository<Report>(context), IReportRepository;