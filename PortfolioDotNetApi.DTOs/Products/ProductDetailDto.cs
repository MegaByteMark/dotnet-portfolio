namespace PortfolioDotNetApi.DTOs.Products;

public class ProductDetailDto: ProductSummaryDto
{
    public required string Description { get; set; } = string.Empty;
    public required decimal Price { get; set; }
}