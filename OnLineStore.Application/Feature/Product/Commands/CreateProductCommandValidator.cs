using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.Product.Commands
{
   public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(p => p.PName)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(100).WithMessage("Product Name must not exceed 100 characters.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(p => p.CId)
               .GreaterThan(0).WithMessage("Category ID must be a positive integer.");

        }
    }
}
