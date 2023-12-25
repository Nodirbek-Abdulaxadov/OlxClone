

using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class User:BaseEntity
{
    [MinLength(5), MaxLength(100)]
    public string? FullName { get; set; }
    [MinLength(3), MaxLength(500)]
    public string? UserName { get; set; }
    [EmailAddress, MinLength(5), MaxLength(200)]
    public string? Email { get; set; }
    [MaxLength(50), MinLength(3)]
    public string? PhoneNumber { get; set; }

    [MaxLength(50), MinLength(8)]
    public string? PasswordHash { get; set; }

    [MaxLength(500), MinLength(3)]
    public string? ImageUrl { get; set; }

    public bool? IsOnline { get; set; }

    public DateTime? LastActive { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();
    public virtual ICollection<Chat> ChatUser1s { get; set; } = new List<Chat>();
    public virtual ICollection<Chat> ChatUser2s { get; set; } = new List<Chat>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}

