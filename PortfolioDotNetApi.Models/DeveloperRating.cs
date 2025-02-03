using System.ComponentModel.DataAnnotations;
using IntraDotNet.EntityFrameworkCore.Optimizations.Interfaces;

namespace PortfolioDotNetApi.Models;

public class DeveloperRating : IAuditable, IRowVersion
{
    [Key]
    public Guid? DeveloperId { get; set; }
    public Developer? Developer { get; set; }
    [Key]
    public Guid? RatingId { get; set; }
    public Rating? Rating { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    [MaxLength(255)]
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdateOn { get; set; }
    [MaxLength(255)]
    public string? LastUpdateBy { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
    [MaxLength(255)]
    public string? DeletedBy { get; set; }
    public byte[]? RowVersion {get;set;}

    public DeveloperRating() { }
}
