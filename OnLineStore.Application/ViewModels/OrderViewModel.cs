using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.ViewModels
{
    public class OrderViewModel
    {
        public int OId { get; set; }

        public string? UId { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool? Paid { get; set; }

        public DateOnly? Date { get; set; }

        public string? Status { get; set; }

        public int? TId { get; set; }
    }
}
