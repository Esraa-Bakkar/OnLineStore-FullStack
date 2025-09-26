using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Application.ViewModels
{
   
    
        public enum PaymentTypeEnum
        {
            CreditCard,
            Paypal,
            Cash
        }

        public class PaymentMethodViewModel
        {
            public int OrderId { get; set; }

            public PaymentTypeEnum PaymentMethod { get; set; }

            public decimal Amount { get; set; }
        }
}


