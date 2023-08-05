

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flash_card.Models
{
  public class Word
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    [Column("title",TypeName = "nvarchar(50)")]
    public string? Title { get; set; }
    
    [StringLength(250)]
    [Column("example",TypeName = "nvarchar(250)")]
    public string? Example { get; set; }
    
    [Required]
    [StringLength(500)]
    [Column("defination",TypeName = "nvarchar(500)")]
    public string? Defination { get; set; }
    
    [Column("createdate", TypeName ="nvarchar(30)")]
    public string? CreateDate { get; set; }

    [Column("learntimes",TypeName ="int")]
    public int LearnTime { get; set; }
  }
}
