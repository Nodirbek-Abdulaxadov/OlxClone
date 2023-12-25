
using DataAccesLayer.Models;

namespace DTO.DTOs.MessageDtos;

public partial class MessageDto:BaseDto
{
    public int? ChatId { get; set; }

    public int? UserId { get; set; }

    public string? Text { get; set; }

    public virtual Chat? Chat { get; set; }

    public virtual User? User { get; set; }
}
