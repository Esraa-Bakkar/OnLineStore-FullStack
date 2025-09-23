using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.Cart.Command
{
   public class CreateCartCommand : IRequest<CartViewModel>
    {
       

        public string UserId { get; set; }
        public DateOnly Date { get; set; }
       
    }
}
