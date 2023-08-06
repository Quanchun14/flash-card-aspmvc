

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flash_card.Models
{
  public class Word
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "{0} must be filled")]
    [StringLength(50, MinimumLength = 1,ErrorMessage = "{0} must from {2} to {1} character")]
    [Column("title",TypeName = "nvarchar(50)")]
    public string? Title { get; set; }
    
    [StringLength(500, ErrorMessage ="{0} must less than 250 characters")]
    [Column("example",TypeName = "nvarchar(250)")]
    public string? Example { get; set; }
    
    [Required(ErrorMessage = "{0} must be filled")]
    [StringLength(250, MinimumLength = 1,ErrorMessage = "{0} must from {2} to {1} characters")]
    [Column("defination",TypeName = "nvarchar(500)")]
    public string? Defination { get; set; }
    
    [Column("createdate", TypeName ="nvarchar(30)")]
    public string? CreateDate { get; set; }

    [Column("learntimes",TypeName ="int")]
    public int LearnTime { get; set; }
  }
}
