using Microsoft.AspNetCore.Mvc;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.Cart.Queries;
using OnLineStore.Application.Feature.Cart.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using OnLineStore.Application.Feature.CartItem.Command;
using System.Security.Claims;
using OnLineStore.Domain.Entities;
using OnLineStore.Application.Feature.Product.Queries;

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
                UserId = cartVw.UserId,
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
      
        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
             
                return Challenge();
            }

            var cart = await _mediator.Send(new GetCartByUserIdQuery { UserId = userId });

            if (cart == null)
            {
                return View("EmptyCart"); 
            }

            return View(cart);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            var cart = await _mediator.Send(new GetCartByUserIdQuery { UserId = userId });
            if (cart == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var existingItem = cart.Items.FirstOrDefault(item => item.PId == productId);
            var productDetails = await _mediator.Send(new GetProductByIDQuery { Id = productId });

            if (existingItem == null)
            {
                var createCartItemCommand = new CreateCartItemCommand
                {
                    TId = cart.Id,
                    PId = productId,
                    Quantity = 1,
                    Price = (decimal)productDetails.Price
                };
                await _mediator.Send(createCartItemCommand);
            }
            else if (existingItem.PId.HasValue) 
            {
                var updateCartItemCommand = new UpdateCartItemCommand
                {
                    ItemId = existingItem.ItemId,
                    PId = existingItem.PId.Value, 
                    Quantity = existingItem.Quantity.GetValueOrDefault() + 1,
                    Price = (decimal)productDetails.Price*(existingItem.Quantity.GetValueOrDefault()+1)
                };
                await _mediator.Send(updateCartItemCommand); 
            }

            return RedirectToAction("MyCart");
        }

        

    }
}
