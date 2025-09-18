using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;
using MediatR;

namespace OnLineStore.Application.Feature.Product.Queries
{
    public class GetAllProductsQuery:IRequest<IEnumerable<ProductViewModel>>
    {
    }
}
