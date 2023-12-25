
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class SubRegion:BaseEntity
{

    public int? RegionId { get; set; }

    [MinLength(3) , MaxLength(500)]
    public string? Name { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();


    public virtual Region? Region { get; set; }
}
