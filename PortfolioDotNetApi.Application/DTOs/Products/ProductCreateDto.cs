namespace PortfolioDotNetApi.DTOs.Products;

public class ProductCreateDto
{
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required decimal Price { get; set; }
}