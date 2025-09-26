using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Order.Queries
{
  public  class GetOrderByUserIdQuery : IRequest <OrderViewModel>
    {
        public string UserId { get; set; }
    }
}
