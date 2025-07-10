namespace PortfolioDotNetApi.DTOs;

public class CustomerSummaryDto
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}