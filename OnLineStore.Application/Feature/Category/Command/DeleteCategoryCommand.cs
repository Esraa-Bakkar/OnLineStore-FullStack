using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Category.Command
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int CId { get; set; }
    }
}
