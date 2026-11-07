using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.Dtos;
using ProductAPI.Application.Interfaces;

namespace ProductAPI.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ProductCreatedto dto)
        {
            var result = await _productService.CreateProductAsync(dto);

            // Returns 201 Created status with location route
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
    }
}
