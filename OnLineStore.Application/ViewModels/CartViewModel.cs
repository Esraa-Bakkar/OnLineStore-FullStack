using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.ViewModels
{
   public class CartViewModel
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public string? UserId { get; set; }
    }
}
