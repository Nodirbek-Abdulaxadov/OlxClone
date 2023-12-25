
using DataAccesLayer.Models;

namespace DTO.DTOs.RegionDtos;

public class UpdateRegionDto:BaseDto
{
    public string? Name { get; set; }

    public virtual ICollection<SubRegion> SubRegions { get; set; } = new List<SubRegion>();
}
