using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class CreateOrderCommand : IRequest<int>
    {
       // public int OId { get; set; }

        public int? UId { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool? Paid { get; set; }

        public DateOnly? Date { get; set; }

        public string? Status { get; set; }

        public int? TId { get; set; }
    }
}
