using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Order.Queries;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.Order.Command;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace OnLineStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return View("GetAllOrders", orders);
        }

        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            return View("GetOrderById", order);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            return View("CreateOrder");
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel orderVm)
        {
            var result = await _mediator.Send(new CreateOrderCommand {
                UId = orderVm.UId,
                TId = orderVm.TId,
                Date = orderVm.Date,
                TotalPrice = orderVm.TotalPrice,
                Status = orderVm.Status,
                Paid = orderVm.Paid
            });
            if (result != null)
                return RedirectToAction("GetAllOrders");


            ModelState.AddModelError("", "Failed to create order");
            return View("CreateOrder", orderVm);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            return View("DeleteOrder", order);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteOrderConfirmed(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand { OrderId = id });
            if (result)
                return RedirectToAction("GetAllOrders");

            ModelState.AddModelError("", "Failed to delete order");
            return RedirectToAction("DeleteOrder", new { id });
        }



        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            return View("UpdateOrder", order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderViewModel orderVm)
        {
            var result = await _mediator.Send(new UpdateOrderCommand
            {
                OrderId = orderVm.OId,
                UId = orderVm.UId,
                TId = orderVm.TId,
                Date = orderVm.Date,
                TotalPrice = orderVm.TotalPrice,
                Status = orderVm.Status,
                Paid = orderVm.Paid
            });

            if (result != null)
                return RedirectToAction("GetAllOrders");

            ModelState.AddModelError("", "Failed to update order");
            return View("UpdateOrder", orderVm);
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            
            var existingOrder = await _mediator.Send(new GetOrderByUserIdQuery { UserId = userId });

            if (existingOrder != null && existingOrder.CartItems.Any())
            {
                return View(existingOrder); 
            }

           
            var newOrderId = await _mediator.Send(new CheckoutCommand { UserId = userId });

            if (newOrderId <= 0)
            {
                
                TempData["Error"] = "Something went wrong while creating your order.";
                return RedirectToAction("GetAllProductsForCustmer", "Product");
            }

          
            var newOrder = await _mediator.Send(new GetOrderByIdQuery { OrderId = newOrderId });
            return View(newOrder);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ActionName("Checkout")]
        public async Task<IActionResult> CheckoutPost()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

           
            var latestOrder = await _mediator.Send(new GetOrderByUserIdQuery { UserId = userId });

            if (latestOrder == null)
            {
                ModelState.AddModelError("", "No order found to confirm.");
                return RedirectToAction("GetAllProductsForCustmer", "Product");
            }

            
            return RedirectToAction("Pay", "Payment", new { orderId = latestOrder.OId });
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Pay(int orderId)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = orderId });

            if (order == null || order.Paid == true)
            {
                return RedirectToAction("GetAllProductsForCustmer", "Product");
            }

            return View("Pay", order);
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Payment(int orderId)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery {OrderId= orderId });

            if (order == null)
                return NotFound();

            var model = new PaymentMethodViewModel
            {
                OrderId = order.OId,
                Amount = order.TotalPrice ?? 0
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> SuccessPayment(PaymentMethodViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Payment", model);

            var result = await _mediator.Send(new ConfirmPaymentCommand
            {
                OrderId = model.OrderId,
                
                Amount = model.Amount
            });

            if (result)
            {
                TempData["Success"] = "✅ Payment completed successfully!";
                return RedirectToAction("PaymentSuccess", new { orderId = model.OrderId });
            }

            TempData["Error"] = "❌ Payment failed. Please try again.";
            return View("Payment", model);
        }

        [HttpGet]
        public IActionResult PaymentSuccess(int orderId)
        {
           
            return View(orderId);
        }





















    }
}
