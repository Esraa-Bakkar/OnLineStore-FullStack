using System;
using System.Collections.Generic;



namespace OnLineStore.Domain.Entities;

public partial class Product
{
   
    public int PId { get; set; }

    public string? PName { get; set; }

    public decimal? Price { get; set; }

    public string? ImgePath { get; set; }

    public int? Stock { get; set; }

    public int? CId { get; set; }

    public virtual Catagory? CIdNavigation { get; set; }

    public virtual ICollection<CartItem>? CartItem { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
