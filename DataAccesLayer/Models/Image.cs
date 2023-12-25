

using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class Image:BaseEntity
{
    [MinLength(5), MaxLength(300)]
    public string? Url { get; set; }

    public int? AdsElonId { get; set; }

    public virtual AdsElon? AdsElons { get; set; }
}

