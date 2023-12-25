

using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class SubCategory:BaseEntity
{

    public int? CategoryId { get; set; }
    [MinLength(3), MaxLength(500)]
    public string? Name { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();

    public virtual Category? Category { get; set; }
}
