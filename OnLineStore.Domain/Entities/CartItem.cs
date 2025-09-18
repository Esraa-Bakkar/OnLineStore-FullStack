using System;
using System.Collections.Generic;

namespace OnLineStore.Domain.Entities;

public partial class CartItem
{
    public int? ItemId { get; set; }

    public int PId { get; set; }

    public int? TId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Product PIdNavigation { get; set; } = null!;

    public virtual Cart? TIdNavigation { get; set; }
}
