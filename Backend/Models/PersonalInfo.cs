using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
  public class PersonalInfo
  {
    [Key]
    public int PersonalInfoId { get; set; }

    [Required]
    [StringLength(9)] // Assuming SSN is 9 digits
    public string SSN { get; set; } = null!;

    // Assuming routing and account numbers can be stored as integers
    public long RoutingNumber { get; set; }
    public long AccountNumber { get; set; }

    public DateTime Birthdate { get; set; }
    public DateTime HireDate { get; set; }


  }
}
