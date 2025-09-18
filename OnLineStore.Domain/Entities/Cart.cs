using System;
using System.Collections.Generic;

namespace OnLineStore.Domain.Entities;

public partial class Cart
{
    public int TId { get; set; }

    public DateOnly? Date { get; set; }

    public int? UId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? UIdNavigation { get; set; }
}
