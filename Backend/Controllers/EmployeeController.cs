using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Context;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
  private readonly ApplicationDbContext _dbContext; // Replace YourDbContext with the actual name of your DbContext

  public EmployeesController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpPost]
  public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
  {
    if (ModelState.IsValid)
    {
      // Add the employee to the database
      _dbContext.Employees.Add(employee);
      await _dbContext.SaveChangesAsync();

      // Return the created employee with a 201 Created status
      return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    // Return a 400 Bad Request with validation errors if the model is not valid
    return BadRequest(ModelState);
  }

  [HttpGet("{id}")]
  public IActionResult GetEmployee(int id)
  {
    // Retrieve the employee by id
    var employee = _dbContext.Employees.Find(id);

    if (employee == null)
    {
      // Return a 404 Not Found if the employee is not found
      return NotFound();
    }

    // Return the employee with a 200 OK status
    return Ok(employee);
  }
}
