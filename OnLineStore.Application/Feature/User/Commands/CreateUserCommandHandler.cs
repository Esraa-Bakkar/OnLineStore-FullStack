using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.User.Commands
{
   public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,UserViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public CreateUserCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var user = new Domain.Entities.User
           {
              
               UName = request.Name,
               Email = request.Email,
               Phone = request.Phone,
               Address = request.Address
           };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            var userViewModel = new UserViewModel
            {
                Id = user.UId,
                Name = user.UName,
                Password = request.Password,
                Email = user.Email,
                Phone = user.Phone,
               Address = user.Address
            };
            return userViewModel;

        }
    }
}
