using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class ConfirmPaymentCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }

}
