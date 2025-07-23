namespace PortfolioDotNetApi.DTOs.Customers;

public class CustomerCreateDto
{
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string LoyaltyCardNo { get; set; } = string.Empty;
}