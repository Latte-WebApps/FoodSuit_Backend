using FoodSuit_Backend.Finance.Domain.Model.Entities;
using FoodSuit_Backend.Finance.Domain.Model.Queries;

namespace FoodSuit_Backend.Finance.Domain.Services;

public interface IReportQueryService
{
    Task<IEnumerable<Report>> Handle(GetAllReportsQuery query);
    
    Task<Report?> Handle(GetReportByIdQuery query);
}