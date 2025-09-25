using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.ViewModels
{
   public class CartItemViewModel
    {
        public int ItemId { get; set; }
        public int ?PId { get; set; }
        public string ProductName { get; set; }
        public string ImagPath { get; set; } 
        public int? TId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        

    }
}
