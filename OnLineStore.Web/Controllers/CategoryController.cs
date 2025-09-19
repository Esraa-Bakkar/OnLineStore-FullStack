using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Category.Queries;
using OnLineStore.Application.Feature.Category.Command;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _medoatr;

        public CategoryController(IMediator medoatr)
        {
            _medoatr = medoatr;
        }

        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _medoatr.Send(new GetAllCategoryQuery());
            return View("GetAllCategories", result);
        }

        public async Task<IActionResult> GetCategory([FromQuery] int id)
        {
            var result = await _medoatr.Send(new GetCategoryByIdQuery { CId = id });
            return View("GetCategoryById", result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(string name, string description)
        {
            var result = await _medoatr.Send(new AddCategoryCommand
            {
                CName = name,
                Description = description
            });

            return View("AddCategory", result);
        }

     
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            
            var category = await _medoatr.Send(new GetCategoryByIdQuery { CId = id });
            return View("DeleteCategory", category);
        }

       
        [HttpPost, ActionName("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            await _medoatr.Send(new DeleteCategoryCommand { CId = id });
            TempData["DeletedId"] = id; 
            return RedirectToAction("DeleteSuccess");
        }

        
        public IActionResult DeleteSuccess()
        {
            ViewBag.DeletedId = TempData["DeletedId"];
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _medoatr.Send(new GetCategoryByIdQuery { CId = id });
            if (category == null)
            {
                return NotFound();
            }
            return View("Update", category); 
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", command);
            }

            await _medoatr.Send(command);

            return RedirectToAction("GetAllCategory"); 
        }

    }
}
