using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class PayGrade
  {
    [Key]
    public int PayGradeId { get; set; }
    public int PayAmount { get; set; }
  
  }
}
