using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.ViewModels
{
  public  class ProductViewModel
    {
        public int PId { get; set; }

        public string? PName { get; set; }

        public decimal? Price { get; set; }

        public string? ImgePath { get; set; }
    }
}
