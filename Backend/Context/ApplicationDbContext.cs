using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
  public class ApplicationDbContext : DbContext
  {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }



  }
}
