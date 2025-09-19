using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
    {
        public int CId { get; set; }
    }
}
