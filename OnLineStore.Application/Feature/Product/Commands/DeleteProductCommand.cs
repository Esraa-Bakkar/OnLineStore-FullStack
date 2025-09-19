using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.Product.Commands
{
   public class DeleteProductCommand : IRequest<String>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int id) {
            Id = id;
        }
    }
}
