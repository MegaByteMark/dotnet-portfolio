using System.ComponentModel.DataAnnotations;
using IntraDotNet.Domain.Core;

namespace PortfolioDotNetApi.Domain.Entities;

public class Product: IAuditable, IRowVersion
{
    [Key]
    [Required]
    public int? Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Required]
    public required string Description { get; set; } = string.Empty;

    [Required]
    public required decimal Price { get; set; }

    public DateTimeOffset? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdateOn { get; set; }
    public string? LastUpdateBy { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
    public string? DeletedBy { get; set; }
    public byte[]? RowVersion { get; set; }
}