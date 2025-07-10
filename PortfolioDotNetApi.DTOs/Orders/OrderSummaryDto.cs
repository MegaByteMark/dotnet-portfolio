namespace PortfolioDotNetApi.DTOs.Orders;

public class OrderSummaryDto
{
    public required int Id { get; set; }
    public required DateTime OrderDate { get; set; }
    public required CustomerSummaryDto Customer { get; set; }
    public required decimal TotalAmount { get; set; }
    public required string Status { get; set; }
}
