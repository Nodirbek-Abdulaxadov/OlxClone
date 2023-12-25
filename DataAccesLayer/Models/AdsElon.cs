using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Models;

public partial class AdsElon :BaseEntity
{
    [Required, Column("UserID")]
    public int? UserId { get; set; }

    [Required, MinLength(3), MaxLength(500)]
    public string? Title { get; set; }
    
    public decimal? Price { get; set; }
    [MinLength(10), MaxLength(2000)]
    public string? Description { get; set; }

    [MinLength(3) , MaxLength(300), Column("Photo")]
    public string? Photo { get; set; }
    [Required]
    public int? SubCategoryId { get; set; }

    public int? SubRegionId { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual SubCategory? SubCategory { get; set; }

    public virtual SubRegion? SubRegionNavigation { get; set; }

    public virtual User? User { get; set; }
}
