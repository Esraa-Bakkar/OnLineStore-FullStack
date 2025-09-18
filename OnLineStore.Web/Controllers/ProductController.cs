using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Product.Queries;

namespace OnLineStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult GetAllProducts()
        {
            var Products = _mediator.Send(new GetAllProductsQuery()).Result;
            return View(Products);
        }
    }
}
