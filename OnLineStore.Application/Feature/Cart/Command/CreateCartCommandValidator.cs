using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.Cart.Command
{
  public  class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
           
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .Must(date => date <= DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date cannot be in the future.");
        }
    }
}
