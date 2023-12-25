using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public class Category : BaseEntity
{
    [Required, MinLength(2), MaxLength(500)]
    public string? Name { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
