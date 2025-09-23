using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Order.Command
{
    public class UpdateOrderCommand : IRequest<OrderViewModel>
    {

        public int OrderId { get; set; }

        public string? UId { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool? Paid { get; set; }

        public DateOnly? Date { get; set; }

        public string? Status { get; set; }

        public int? TId { get; set; }
    }
}
