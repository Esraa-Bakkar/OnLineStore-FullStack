using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.CartItem.Queries
{
   public class GetCartItemByIDQuery : IRequest<CartItemViewModel>
    {
        public int ItemId { get; set; }

    }
}
