namespace PortfolioDotNetApi.DTOs.Employees;

public class EmployeeSummaryDto
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Position { get; set; } = string.Empty;
}
