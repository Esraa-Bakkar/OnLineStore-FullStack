using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.CartItem.Command
{
   public class UpdateCartItemCommandValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemCommandValidator()
        {
            RuleFor(x => x.ItemId).GreaterThan(0).WithMessage("ItemId must be greater than 0");
            RuleFor(x => x.PId).GreaterThan(0).WithMessage("PId must be greater than 0");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    
    }

