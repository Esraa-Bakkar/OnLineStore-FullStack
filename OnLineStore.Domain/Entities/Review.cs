// Review.cs
namespace OnLineStore.Domain.Entities;

public partial class Review
{
    public int RId { get; set; }

  
    public string? UId { get; set; }

    public int? PId { get; set; }
    public decimal? Rating { get; set; }
    public string? Comment { get; set; }

    public virtual Product? PIdNavigation { get; set; }

    
    public virtual ApplicationUser? UIdNavigation { get; set; }
}
