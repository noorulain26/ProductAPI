
using ProductAPI.Application.Dtos;
namespace ProductAPI.Application.Interfaces;

public interface IProductService
{
    Task<ProductResponseDto> CreateProductAsync(ProductCreatedto dto);
}
