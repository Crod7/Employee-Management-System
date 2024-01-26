using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class Employee
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;

    // Foreign Key
    [ForeignKey("Role")]
    public int RoleId { get; set; }

    [ForeignKey("PayGrade")]
    public int PayGradeId { get; set; }

    [ForeignKey("PersonalInfo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? PersonalInfoId { get; set; }

    [ForeignKey("Schedule")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? ScheduleId { get; set; }



    // Navigation Property
    public Role? Role { get; set; } = null!;
    public PayGrade? PayGrade { get; set; } = null!;
    public PersonalInfo? PersonalInfo { get; set; } = null!;
    public Schedule? Schedule { get; set; } = null!;



    // Navigation property for one-to-many relationship
    public ICollection<TimeOffRequest>? TimeOffRequest { get; set; }
    public ICollection<Performance>? Performance { get; set; }
  }
}
