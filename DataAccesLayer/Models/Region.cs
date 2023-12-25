
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class Region:BaseEntity
{

    [Required, MinLength(3), MaxLength(1000)]
    public string? Name { get; set; }

    public virtual ICollection<SubRegion> SubRegions { get; set; } = new List<SubRegion>();
}
