using PortfolioDotNetApi.DTOs.Products;

namespace PortfolioDotNetApi.DTOs.Orders;

public class OrderItemDetailDto
{
    public required int Id { get; set; }
    public required ProductDetailDto Product { get; set; }
    public required int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}