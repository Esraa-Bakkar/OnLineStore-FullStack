using MediatR;
using OnLineStore.Application.ViewModels;

namespace OnLineStore.Application.Feature.Cart.Queries
{
    public class GetCartByUserIdQuery : IRequest<CartViewModel>
    {
        public string UserId { get; set; }
    }
}