using System;
using System.Collections.Generic;

namespace OnLineStore.Domain.Entities;

public partial class User
{
    public int UId { get; set; }

    public string? UName { get; set; }

    public bool? Admin { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
