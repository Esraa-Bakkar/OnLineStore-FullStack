using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Order.Queries;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.Order.Command;

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
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId=id });
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











    }
}
