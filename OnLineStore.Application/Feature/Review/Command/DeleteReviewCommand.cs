using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int ReviewId { get; set; }
    }
}
