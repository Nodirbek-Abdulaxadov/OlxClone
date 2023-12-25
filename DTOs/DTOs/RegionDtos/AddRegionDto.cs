

using DataAccesLayer.Models;

namespace DTO.DTOs.RegionDtos;

public partial class AddRegionDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SubRegion> SubRegions { get; set; } = new List<SubRegion>();
}
