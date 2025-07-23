namespace PortfolioDotNetApi.Domain.Entities;

public enum OrderStatus
{
    New = 1,
    Pending= 2,
    Completed = 3,
    Cancelled = 4,
    Shipped = 5,
    Delivered = 6
}