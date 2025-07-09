using System.ComponentModel.DataAnnotations;
using IntraDotNet.Infrastructure.Core;

namespace PortfolioDotNetApi.Models;

public sealed class Order : IAuditable, IRowVersion
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [Required]
    public required int CustomerId { get; set; }

    [Required]
    public required DateTimeOffset OrderDate { get; set; }

    [Required]
    public required OrderStatus Status { get; set; } = OrderStatus.New;

    public DateTimeOffset? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdateOn { get; set; }
    public string? LastUpdateBy { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
    public string? DeletedBy { get; set; }

    [Required]
    public required Customer Customer { get; set; }
    
    [Required]
    public required List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public byte[]? RowVersion { get; set; }
}