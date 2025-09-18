using System;
using System.Collections.Generic;

namespace OnLineStore.Domain.Entities;

public partial class Order
{
    public int OId { get; set; }

    public int? UId { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? Paid { get; set; }

    public DateOnly? Date { get; set; }

    public string? Status { get; set; }

    public int? TId { get; set; }

    public virtual Cart? TIdNavigation { get; set; }

    public virtual User? UIdNavigation { get; set; }
}
