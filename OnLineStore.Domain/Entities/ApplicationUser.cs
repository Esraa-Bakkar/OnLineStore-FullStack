
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnLineStore.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
      
        public string? Address { get; set; }
       

        
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
