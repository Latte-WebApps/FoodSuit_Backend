using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace FoodSuit_Backend.Orders.Domain.Model.Aggregates;

public partial class Order : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }
}
