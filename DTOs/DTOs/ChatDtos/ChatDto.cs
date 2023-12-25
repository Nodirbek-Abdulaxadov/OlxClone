

using DataAccesLayer.Models;

namespace DTO.DTOs.ChatDtos;

public class ChatDto:BaseDto
{
    public int? User1Id { get; set; }

    public int? User2Id { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual User? User1 { get; set; }

    public virtual User? User2 { get; set; }
}
