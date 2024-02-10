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
    public DbSet<Performance> Performance { get; set; } = null!;

    public DbSet<Role> Role { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>()
          .HasMany(e => e.TimeOffRequest)
          .WithOne(to => to.Employee)
          .HasForeignKey(to => to.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete

     modelBuilder.Entity<Employee>()
          .HasMany(e => e.Performance)  // Create the HasMany relationship with Performance
          .WithOne(p => p.Employee)      // Specify the inverse navigation property
          .HasForeignKey(p => p.EmployeeId) // Specify the foreign key property
          .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete for Performance

      // Add any other entity configurations here

      base.OnModelCreating(modelBuilder);
    }
  }
}
