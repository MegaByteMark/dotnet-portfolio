using System.ComponentModel.DataAnnotations;
using IntraDotNet.EntityFrameworkCore.Optimizations.Interfaces;

namespace PortfolioDotNetApi.Models;

public class Rating : IAuditable, IRowVersion
{
    [Key]
    public Guid? Id { get; set; }
    public required int Score { get; set; }
    public IEnumerable<DeveloperRating>? DeveloperRatings { get; set; }
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

    public Rating() { }
}
