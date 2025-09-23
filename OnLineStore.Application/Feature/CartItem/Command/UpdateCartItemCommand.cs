using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.CartItem.Command
{
    public class UpdateCartItemCommand : IRequest<CartItemViewModel>
    {
        public int ItemId { get; set; }
        public int PId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }

}

