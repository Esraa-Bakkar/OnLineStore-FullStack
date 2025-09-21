using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class CreateReviewCommand : IRequest<int>
    {

        public int? UId { get; set; }

        public int? PId { get; set; }

        public decimal? Rating { get; set; }

        public string? Comment { get; set; }
    }
}
