
using DataAccesLayer.Models;

namespace DTO.DTOs.SubRegionDtos;

public class AddSubRegionDto
{

    public int? RegionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();

    public virtual Region? Region { get; set; }
}
