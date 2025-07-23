using System;

namespace PortfolioDotNetApi.DTOs.Orders;

public class OrderDetailDto: OrderSummaryDto
{
    public required List<OrderItemDetailDto> Items { get; set; }
}
