using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Finance.Domain.Model.Entities;

public class Report
{
    public int Id { get; set; }
    public string Description { get; set; }
    public EReportType Type { get; private set; }
    public string Date { get; set;  }
    public int OrdersId { get; set; }
    public int ProductsId { get; set; }
    
    public Report(EReportType type)
    {
        Description = string.Empty;
        Type = type;
        Date = string.Empty;
        OrdersId = 0;
        ProductsId = 0;
    }
}