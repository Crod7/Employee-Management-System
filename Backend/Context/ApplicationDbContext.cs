using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = null!;
    public DbSet<TimeOffRequest> TimeOffRequest { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>()
          .HasMany(e => e.TimeOffRequest)
          .WithOne(to => to.Employee)
          .HasForeignKey(to => to.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete

      // Add any other entity configurations here

      base.OnModelCreating(modelBuilder);
    }
  }
}
