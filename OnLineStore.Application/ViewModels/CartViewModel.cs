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
        public int? UserId { get; set; }
    }
}
