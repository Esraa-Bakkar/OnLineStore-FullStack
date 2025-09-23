using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.CartItem.Command
{
    public class CreateCartItemCommand : IRequest<CartItemViewModel>
    {
       
        public int PId { get; set; }
        public int TId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
