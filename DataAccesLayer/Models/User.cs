using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Models;

public partial class User : IdentityUser
{
    [MinLength(5), MaxLength(100)]
    public string? FullName { get; set; }

    [MaxLength(500), MinLength(3)]
    public string? ImageUrl { get; set; }

    public bool? IsOnline { get; set; }

    public DateTime? LastActive { get; set; }

    public virtual ICollection<AdsElon> AdsElons { get; set; } = new List<AdsElon>();
    public virtual ICollection<Chat> ChatUser1s { get; set; } = new List<Chat>();
    public virtual ICollection<Chat> ChatUser2s { get; set; } = new List<Chat>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}

