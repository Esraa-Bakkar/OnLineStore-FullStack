using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnLineStore.Application.Feature.Product.Queries;
using OnLineStore.Application.Feature.Product.Commands;
using OnLineStore.Application.ViewModels;
using OnLineStore.Application.Feature.User.Queries;
using OnLineStore.Application.Feature.User.Commands;
using OnLineStore.Domain.Entities;


namespace OnLineStore.Web.Controllers
{
    public class UserController : Controller
    {
       private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return View("GetAllUsers", users);
        }
        [HttpGet]
        public async Task <IActionResult> GetUserByID(string id )
        {
            var user =  await _mediator.Send(new GetuserByIDQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(string Name , string Email,string password,string phone , string address)
        {

            var result = await _mediator.Send(new CreateUserCommand
            {
                Name = Name,
                Email = Email,
                Password = password,
                Phone = phone,
                Address = address


            });
            if (result!=null)
            {
                return RedirectToAction("GetAllUsers");
            }
            return View(result);



        }
        [HttpGet]
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await _mediator.Send(new GetuserByIDQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            if (!ModelState.IsValid)
            {  
                return View(command);
                
            }
             await _mediator.Send(command);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _mediator.Send(new GetuserByIDQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id, UserViewModel uservm)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return RedirectToAction("GetAllUsers");
        }
        





    }
}
