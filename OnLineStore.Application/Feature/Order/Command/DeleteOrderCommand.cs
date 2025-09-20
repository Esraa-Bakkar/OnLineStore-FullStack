using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
