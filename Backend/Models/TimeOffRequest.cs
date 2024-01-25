using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class TimeOffRequest
  {
    [Key]
    public int TimeOffRequestId { get; set; }
    // At end of day system enters total sales for the day
    public string Description { get; set; } = null!;
    public DateTime TimeOffDate { get; set; }

    // Foreign key property
    public int EmployeeId { get; set; }

    // Navigation property for the related Employee
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } = null!;
  }
}
