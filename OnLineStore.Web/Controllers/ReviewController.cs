using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.Feature.Review.Command;
using OnLineStore.Application.Feature.Review.Queries;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _mediator.Send(new GetAllReviewQuery());
            return View("GetAllReviews",reviews);
        }


        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _mediator.Send(new GetReviewByIdQuery { ReviewId= id });
            return View("GetReview",review);
        }

        [HttpGet]
        public async Task<IActionResult> CreateReview()
        {
            return View("CreateReview");
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(GetAllReviews));
            }
            return View("CreateReview", command);
        }

        public async Task<IActionResult> UpdateReview(int id)
        {
            var reviewViewModel = await _mediator.Send(new GetReviewByIdQuery { ReviewId = id });
            if (reviewViewModel == null)
            {
                return NotFound();
            }
            var updateCommand = new UpdateReviewCommand
            {
                RId = reviewViewModel.RId,
                UId = reviewViewModel.UId,
                PId = reviewViewModel.PId,
                Rating = reviewViewModel.Rating,
                Comment = reviewViewModel.Comment
            };
            return View("UpdateReview", updateCommand);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(GetAllReviews));
            }
            return View("UpdateReview", command);
        }

        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _mediator.Send(new GetReviewByIdQuery { ReviewId = id });
            if (review == null)
            {
                return NotFound();
            }
            return View("DeleteReview", review);
        }

       
        [HttpPost, ActionName("DeleteReview")]
        public async Task<IActionResult> DeleteReviewConfirmed(int RId)
        {
            await _mediator.Send(new DeleteReviewCommand { ReviewId = RId });
            return RedirectToAction(nameof(GetAllReviews));
        }

    }
}
