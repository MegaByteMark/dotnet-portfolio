namespace PortfolioDotNetApi.DTOs.Customers;

public class CustomerDetailDto: CustomerSummaryDto
{
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string LoyaltyCardNo { get; set; } = string.Empty;
}