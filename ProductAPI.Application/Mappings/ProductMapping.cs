using ProductAPI.Domain.Entities;
using ProductAPI.Application.Dtos;

namespace ProductAPI.Application.Mappings
{
    public static class ProductMapping
    {
        public static Product ToEntity(this ProductCreatedto dto)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity
            };
        }

        public static ProductResponseDto ToResponseDto(this Product product)
        {
            return new ProductResponseDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.StockQuantity,
                product.CreatedAt
            );
        }
    }
}


            
        
    


