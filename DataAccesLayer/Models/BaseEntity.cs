

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Models;

public partial class BaseEntity
{
    [Key, Required, Column("Id")]
    public int Id { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

}
