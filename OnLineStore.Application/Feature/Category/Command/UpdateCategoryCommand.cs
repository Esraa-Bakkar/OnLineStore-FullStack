using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Category.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryViewModel>
    {
        public int CId { get; set; }
        public string? Description { get; set; }

        public string? CName { get; set; }
    }
}
