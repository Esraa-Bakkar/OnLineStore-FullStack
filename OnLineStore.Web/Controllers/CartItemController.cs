using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.Feature;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.CartItem.Queries;
using OnLineStore.Domain.Entities;
using OnLineStore.Application.Feature.CartItem.Command;


namespace OnLineStore.Web.Controllers
{
    public class CartItemController : Controller
    {
        private readonly IMediator _mediator;
        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var cartItems =  await _mediator.Send(new GetAllCartItemsQuery());
            return View(cartItems);

        }
        [HttpGet]
        public async Task<IActionResult> GetCartItemByID(int id)
        {
            var cartItem =  await _mediator.Send(new GetCartItemByIDQuery { ItemId=id});
            return View(cartItem);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCartItem()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CreateCartItemCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);
            var cartItemId = await _mediator.Send(command);
            return RedirectToAction("GetAllCartItems");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCartItem(int id)
        {
            var cartItem = await _mediator.Send(new GetCartItemByIDQuery { ItemId = id });
            if (cartItem == null)
                return NotFound();
            return View(cartItem);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCartItem(CartItemViewModel cartItemvm)
        {
            if (!ModelState.IsValid)
                return View(cartItemvm);
            var command = new UpdateCartItemCommand
            {
                ItemId = cartItemvm.ItemId,
                PId = cartItemvm.PId.Value,
                Quantity = cartItemvm.Quantity.Value,
                Price = cartItemvm.Price.Value,
            };
            var result = await _mediator.Send(command);
            if(result != null)
            return RedirectToAction("GetAllCartItems");
            return View(cartItemvm);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = await _mediator.Send(new GetCartItemByIDQuery { ItemId = id });
            if (cartItem == null)
                return NotFound();
            return View(cartItem);
        }
        [HttpPost, ActionName("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItemConfirmed(int id)
        {
            await _mediator.Send(new DeleteCartItemCommand { Id = id });
            return RedirectToAction("GetAllCartItems");
        }

    }
}
