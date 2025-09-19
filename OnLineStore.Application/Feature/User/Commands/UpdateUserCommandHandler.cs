using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;
using OnLineStore.Infrastructure.Data;
using OnLineStore.Domain.Entities;

namespace OnLineStore.Application.Feature.User.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateUserCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            user.UName = request.Name;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Address = request.Address;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return new UserViewModel 
            {
               Id=user.UId,
                Name = user.UName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address

            };
        }
    }
}
