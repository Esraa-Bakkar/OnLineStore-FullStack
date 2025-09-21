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
  public  class DeleteCartCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
