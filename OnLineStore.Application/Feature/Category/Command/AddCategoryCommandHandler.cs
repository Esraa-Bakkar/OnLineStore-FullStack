using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnLineStore.Application.ViewModels;
using OnLineStore.Domain.Entities;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Category.Command
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryViewModel>
    {
        private readonly OnlineStoreDbContext _context;
        public AddCategoryCommandHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryViewModel> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Catagory
            {
                CName = command.CName,
                Description = command.Description
            };

            await _context.Catagories.AddAsync(category, cancellationToken);
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
