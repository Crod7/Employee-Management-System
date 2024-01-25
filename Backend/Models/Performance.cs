using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class Performance
  {
    [Key]
    public int PerformanceId { get; set; }
    public float Sales { get; set; }
    public DateTime Date { get; set; }

    // Foreign key property
    public int EmployeeId { get; set; }

    // Navigation property for the related Employee
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } = null!;
  }
}
