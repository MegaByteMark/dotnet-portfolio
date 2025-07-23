namespace PortfolioDotNetApi.DTOs.Orders;

public class OrderItemCreateDto
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}
