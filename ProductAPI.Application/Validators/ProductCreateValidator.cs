using FluentValidation;
using ProductAPI.Application.Dtos;

namespace ProductAPI.Application.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreatedto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
        }
    }
}
