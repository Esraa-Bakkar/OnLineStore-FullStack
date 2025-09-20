using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            
        }
    }
}
