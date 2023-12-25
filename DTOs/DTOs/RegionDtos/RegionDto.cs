

using DataAccesLayer.Models;

namespace DTO.DTOs.RegionDtos;

public partial class RegionDto:BaseDto
{

    public string? Name { get; set; }

    public virtual ICollection<SubRegion> SubRegions { get; set; } = new List<SubRegion>();
}
