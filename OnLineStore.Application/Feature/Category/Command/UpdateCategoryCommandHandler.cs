using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnLineStore.Application.Feature.Category.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,CategoryViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public UpdateCategoryCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryViewModel> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _context.Catagories.FindAsync(command.CId);
            if (category == null)
            {
                throw new Exception("category not found");
            }
            category.CName = command.CName;
            category.Description = command.Description;

            _context.Catagories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);

           
            return new CategoryViewModel
            {
                CId = category.CId,
                CName = category.CName,
                Description = category.Description
            };
        }
    }
}
