using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.Cart.Command
{
   public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
        
          
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
        }
    }
}
