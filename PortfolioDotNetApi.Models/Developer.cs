using System.ComponentModel.DataAnnotations;
using IntraDotNet.EntityFrameworkCore.Interfaces;

namespace PortfolioDotNetApi.Models;

public class Developer : IAuditable, IRowVersion
{
    [Key]
    public Guid? Id { get; set; }
    [MaxLength(255)]
    public required string FirstName { get; set; }
    [MaxLength(255)]
    public required string LastName { get; set; }
    [MaxLength(255)]
    public required string Email { get; set; }
    public required Guid RatingId { get; set; }
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
    public Rating? Rating { get; set; }

    public Developer() { }
}
