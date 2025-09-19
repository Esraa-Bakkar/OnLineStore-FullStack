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
   public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, String>
    {
        private readonly OnlineStoreDbContext _context;
        public DeleteUserCommandHandler(OnlineStoreDbContext context) 
        {
            _context = context;
        }
        public async Task<String> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                return $"User with ID {request.Id} not found.";
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return $"User with ID {request.Id} has been deleted.";
        }
    }
}
