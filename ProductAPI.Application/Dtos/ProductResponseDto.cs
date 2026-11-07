using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Application.Dtos
{
    public record ProductResponseDto(Guid Id, string Name, string Description, decimal Price, int StockQuantity,DateTime CreatedAt);
}
