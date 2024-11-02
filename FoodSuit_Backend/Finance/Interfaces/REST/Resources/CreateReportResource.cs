namespace FoodSuit_Backend.Finance.Interfaces.REST.Resources;

public record CreateReportResource(string Description, string ReportType, string Date, int Amount, int OrdersId, int ProductsId);