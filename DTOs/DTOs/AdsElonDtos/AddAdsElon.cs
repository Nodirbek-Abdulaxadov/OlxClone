
using DataAccesLayer.Models;

namespace DTO.DTOs.AdsElonDtos;

public partial class AddAdsElon
{

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public int? SubCategoryId { get; set; }

    public int? SubRegion { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual SubCategory? SubCategory { get; set; }

    public virtual SubRegion? SubRegionNavigation { get; set; }

    public virtual User? User { get; set; }
}
