using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class UpdateReviewCommand : IRequest<ReviewViewModel>
    {
        public int RId { get; set; }
        public int? UId { get; set; }

        public int? PId { get; set; }

        public decimal? Rating { get; set; }

        public string? Comment { get; set; }
    }
}
