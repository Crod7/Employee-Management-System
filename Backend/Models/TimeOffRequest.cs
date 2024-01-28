using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
  public class TimeOffRequest
  {
    [Key]
    public int TimeOffRequestId { get; set; }
    public string Description { get; set; } = null!;
    public DateTime TimeOffDate { get; set; }

    // Foreign key property
    public int? EmployeeId { get; set; }

    // Use JsonIgnore to prevent circular reference serialization
    [JsonIgnore]
    // Navigation property for the related Employee
    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }
  }
}
