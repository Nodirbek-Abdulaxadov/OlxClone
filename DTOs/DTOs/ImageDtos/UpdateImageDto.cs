

using DataAccesLayer.Models;

namespace DTO.DTOs.ImageDtos;

public partial class UpdateImageDto:BaseDto
{

    public string? Url { get; set; }

    public int? AdsId { get; set; }

    public virtual AdsElon? Ads { get; set; }
}
