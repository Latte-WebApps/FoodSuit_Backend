using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Finance.Domain.Model.Entities;

public class Report
{
    public int Id { get; set; }
    public string Description { get; set; }
    public EReportType Type { get; private set; }
    
    public Report(EReportType type)
    {
        Description = string.Empty;
        Type = type;
    }
}