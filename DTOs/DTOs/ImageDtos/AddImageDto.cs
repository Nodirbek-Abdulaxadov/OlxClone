

using DataAccesLayer.Models;

namespace DTO.DTOs.ImageDtos;

public partial class AddImageDto
{
    public string? Url { get; set; }

    public int? AdsId { get; set; }

    public virtual AdsElon? Ads { get; set; }
}
