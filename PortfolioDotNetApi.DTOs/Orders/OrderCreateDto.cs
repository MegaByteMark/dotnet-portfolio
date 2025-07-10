namespace PortfolioDotNetApi.DTOs.Orders;

public class OrderCreateDto
{
    public required DateTime OrderDate { get; set; }
    public required int CustomerId { get; set; }
    public required List<OrderItemCreateDto> Items { get; set; }
    public string Status { get; set; } = "New";
}