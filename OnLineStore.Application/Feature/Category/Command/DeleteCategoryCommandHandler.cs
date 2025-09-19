using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Category.Command
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand,Unit>
    {
        private  readonly OnlineStoreDbContext _context;
        public DeleteCategoryCommandHandler(OnlineStoreDbContext context)
        {
           _context=context;
        }

        public async Task<Unit> Handle (DeleteCategoryCommand command,CancellationToken cancellationToken)
        {
            var category = await _context.Catagories.FindAsync(command.CId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
             _context.Catagories.Remove(category);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
