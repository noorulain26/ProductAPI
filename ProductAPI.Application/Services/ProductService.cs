using FluentValidation;
using ProductAPI.Application.Dtos;
using ProductAPI.Application.Interfaces;
using ProductAPI.Application.Mappings;

namespace ProductAPI.Application.Services
{
    public class ProductService : IProductService
    {
        // Dependency Injection
        private readonly IMyDbContext _context;
        private readonly IValidator<ProductCreatedto> _validator;

        public ProductService(IMyDbContext context, IValidator<ProductCreatedto> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductCreatedto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var product = dto.ToEntity();

            _context.Products.Add(product);
            await _context.SaveChangesAsync(); // To save changes to the database

            return product.ToResponseDto();
        }
    }
}
