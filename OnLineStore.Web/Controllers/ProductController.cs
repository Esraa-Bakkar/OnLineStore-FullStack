using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Product.Queries;
using OnLineStore.Application.Feature.Product.Commands;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task< IActionResult> GetAllProducts()
        {
            var Products = await _mediator.Send(new GetAllProductsQuery());
            return View(Products);
        }
        public async Task <IActionResult> GetProductById(int id)
        {
            var Product = await _mediator.Send(new GetProductByIDQuery { Id=id});

            return View(Product);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel ProductVm)
        {
            
             
                var result = await _mediator.Send(new  CreateProductCommand
                {
                   PName = ProductVm.PName,
                   Price= ProductVm.Price.Value,    
                    CId =ProductVm.CId.Value
                });
           
            if (result!=null)
            { 
                return RedirectToAction("GetAllProducts");
            }
            return View("CreateProduct",result);

        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _mediator.Send(new GetProductByIDQuery {Id=id });

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel productviewmodel)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateProductCommand
                {
                    Id = productviewmodel.PId,
                    PName = productviewmodel.PName,
                    Price = productviewmodel.Price.Value,
                    CId = productviewmodel.CId.Value
                });

                if (result != null)
                {
                    return RedirectToAction("GetAllProducts");
                }
                return View("UpdateProduct", result);
            }

            return View(productviewmodel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _mediator.Send(new GetProductByIDQuery {Id = id });
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProductConfirmed(int PId) 
        {
            var command = new DeleteProductCommand(PId);
            await _mediator.Send(command);
            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public  async Task<IActionResult> GetAllProductsForCustmer()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View("GetProducts",products); 
        }


    }
}
