using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnLineStore.Application.Feature.Review.Command
{
    public class CreateReviewValidator :AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator() 
        { 
             RuleFor(x => x.PId).NotEmpty().WithMessage("ProductId is required");

            RuleFor(x => x.Comment).NotEmpty().WithMessage("ReviewText is required");

            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is required")
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5"); ;

            RuleFor(x => x.UId).NotEmpty().WithMessage("UserId is required");


        }
    }
}
