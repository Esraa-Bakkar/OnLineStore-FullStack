using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class CheckoutCommand : IRequest<int>
    {
        public string UserId { get; set; }
    }

}
