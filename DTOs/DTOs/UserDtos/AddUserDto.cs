

using DataAccesLayer.Models;

namespace DTO.DTOs.UserDtos;

public class AddUserDto
{

    public string? FullName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PasswordHash { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsOnline { get; set; }

    public DateTime? LastActive { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();

    public virtual ICollection<Chat> ChatUser1s { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatUser2s { get; set; } = new List<Chat>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
