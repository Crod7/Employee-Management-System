using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Schedule
  {
    [Key]
    public int ScheduleId { get; set; }

    public DateTime? MondayStart { get; set; }
    public DateTime? MondayEnd { get; set; }

    public DateTime? TuesdayStart { get; set; }
    public DateTime? TuesdayEnd { get; set; }

    public DateTime? WednesdayStart { get; set; }
    public DateTime? WednesdayEnd { get; set; }

    public DateTime? ThursdayStart { get; set; }
    public DateTime? ThursdayEnd { get; set; }

    public DateTime? FridayStart { get; set; }
    public DateTime? FridayEnd { get; set; }

    public DateTime? SaturdayStart { get; set; }
    public DateTime? SaturdayEnd { get; set; }

    public DateTime? SundayStart { get; set; }
    public DateTime? SundayEnd { get; set; }
  }
}
