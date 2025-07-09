using System.ComponentModel.DataAnnotations;
using IntraDotNet.Infrastructure.Core;

namespace PortfolioDotNetApi.Models;

public abstract class Person: IAuditable, IRowVersion
{
    public Person()
    {
    }

    [Key]
    [Required]
    public int? Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public required string LastName { get; set; } = string.Empty;

    [Required]
    public required DateTimeOffset DateOfBirth { get; set; }

    [Required]
    [MaxLength(320)]
    public required string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTimeOffset? CreatedOn { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastUpdateOn { get; set; }
    public string? LastUpdateBy { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
    public string? DeletedBy { get; set; }
    public byte[]? RowVersion { get; set; }
}
