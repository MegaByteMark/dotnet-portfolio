using System.ComponentModel.DataAnnotations;

namespace PortfolioDotNetApi.Domain.Entities;

public sealed class Customer: Person
{
    [MaxLength(50)]
    public string? LoyaltyCardNo { get; set; }
}