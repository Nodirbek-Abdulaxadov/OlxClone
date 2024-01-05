

namespace DataAccesLayer.Models;

public partial class Message:BaseEntity
{

    public int? ChatId { get; set; }

    public string? UserId { get; set; }

    public string? Text { get; set; }

    public virtual Chat? Chat { get; set; }

    public virtual User? User { get; set; }
}
