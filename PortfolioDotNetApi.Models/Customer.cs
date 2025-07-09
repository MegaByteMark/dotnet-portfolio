using System.ComponentModel.DataAnnotations;

namespace PortfolioDotNetApi.Models;

public sealed class Customer: Person
{
    [MaxLength(50)]
    public string? LoyaltyCardNo { get; set; }
}