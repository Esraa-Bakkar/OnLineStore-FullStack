using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.Product.Commands
{
   public class UpdateProductCommand : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public decimal Price { get; set; }
        public int CId { get; set; }
        
    }
}
