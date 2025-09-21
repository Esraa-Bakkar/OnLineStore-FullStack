using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.Cart.Queries;
using OnLineStore.Application.Feature.Cart.Command;
using MediatR;

namespace OnLineStore.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _mediator.Send(new GetAllCartsQuery());
            return View(carts);
        }
        [HttpGet]
        public async Task<IActionResult> GetCartById(int id)
        {
            var cart = await _mediator.Send(new GetCartByIDQuery { Id = id });
            return View(cart);
        }
        [HttpGet]
        public IActionResult CreateCart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart(CreateCartCommand command)
        {
            if (!ModelState.IsValid)
                return View(command); 

            var cartId = await _mediator.Send(command);
            return RedirectToAction("GetAllCarts");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCart(int id)
        {
            var cart = await _mediator.Send(new GetCartByIDQuery { Id = id });
            if (cart == null)
                return NotFound();

            return View(cart); 
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCart(CartViewModel cartVw)
        {
            if (!ModelState.IsValid)
                return View(cartVw);

            var command = new UpdateCartCommand
            {
                Id = cartVw.Id,
                UserId = cartVw.UserId.Value,
                Date = cartVw.Date.Value
            };

            var result = await _mediator.Send(command);

            if (result != null)
                return RedirectToAction("GetAllCarts");

           
            return View(cartVw);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _mediator.Send(new GetCartByIDQuery { Id = id });
            if (cart == null)
                return NotFound();

            return View(cart);
        }
        [HttpPost, ActionName("DeleteCart")]
        public async Task<IActionResult> DeleteCartConfirmed(int id)
        {
            var command = new DeleteCartCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction("GetAllCarts");
        }

    }
}
