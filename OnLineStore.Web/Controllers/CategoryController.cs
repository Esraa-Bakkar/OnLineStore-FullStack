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
    }
}
