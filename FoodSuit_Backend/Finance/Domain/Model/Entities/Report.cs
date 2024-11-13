using FoodSuit_Backend.Finance.Domain.Model.ValueObjects;

namespace FoodSuit_Backend.Finance.Domain.Model.Entities;

/// <summary>
/// Report Entity
/// </summary>
/// <remarks>
/// This class represents a Report entity,
/// containing the properties and methods to manage the information.
/// </remarks>
public class Report
{
    public int Id { get; set; }
    public string Description { get; set; }
    public EReportType Type { get; private set; }
    public string Date { get; set;  }
    public int Amount { get; set; }
    public int OrdersId { get; set; }
    public int ProductsId { get; set; }
    
    public Report(EReportType type)
    {
        Description = string.Empty;
        Type = type;
        Date = string.Empty;
        Amount = 0;
        OrdersId = 0;
        ProductsId = 0;
    }
}