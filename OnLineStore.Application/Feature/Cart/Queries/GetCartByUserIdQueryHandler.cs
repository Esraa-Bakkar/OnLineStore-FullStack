using MediatR;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Application.ViewModels;
using OnLineStore.Infrastructure.Data;

namespace OnLineStore.Application.Feature.Cart.Queries
{
    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery, CartViewModel>
    {
        private readonly OnlineStoreDbContext _context;

        public GetCartByUserIdQueryHandler(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task<CartViewModel> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            // الخطوة 1: نستخدم ThenInclude لجلب تفاصيل المنتج مع كل عنصر في السلة
            var cart = await _context.Carts
                                     .Include(c => c.CartItems)
                                        .ThenInclude(ci => ci.PIdNavigation) // <-- تعديل مهم لجلب بيانات المنتج
                                     .FirstOrDefaultAsync(c => c.UId == request.UserId, cancellationToken);

            if (cart == null)
            {
                return null;
            }

            // الخطوة 2: نقوم بتحويل البيانات إلى ViewModel
            var cartViewModel = new CartViewModel
            {
                Id = cart.TId,
                UserId = cart.UId,
                Date = cart.Date,

                // هنا نقوم بتحويل كل عنصر في السلة إلى شكله النهائي للعرض
                Items = cart.CartItems.Select(item => new CartItemViewModel
                {
                    ItemId = item.ItemId,
                    PId = item.PId,
                   // ProductName = item.PIdNavigation?.PName, // اسم المنتج
                   // ProductImagePath = item.PIdNavigation?.ImgePath, // صورة المنتج
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList(),

              
            };

            return cartViewModel;
        }
    }
}