using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.Product.Commands
{
   public class CreateProductCommand : IRequest<ProductViewModel>
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public decimal Price { get; set; }
        public int  CId { get; set; }
        
    }
}
