using System.ComponentModel.DataAnnotations;

namespace PortfolioDotNetApi.Domain.Entities;

public sealed class Employee : Person
{
    [Required]
    [MaxLength(50)]
    public required string EmployeeId { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required]
    public required DateTimeOffset HireDate { get; set; }

    [Required]
    public required decimal Salary { get; set; }

    [MaxLength(100)]
    [Required]
    public required string Position { get; set; }
}
