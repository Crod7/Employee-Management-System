using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Context;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
  private readonly ApplicationDbContext _dbContext;

  public EmployeesController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  /*
 * HTTP: POST
 * URL: /api/employees
 * BODY: 
  {
    "Name": "John Doe",
    "Email": "john.doe@example.com",
    "Phone": "123-456-7890",
    "Address": "123 Main St",
    "City": "Anytown",
    "State": "CA",
    "PostalCode": "12345",
    "RoleId": 1, // Lowest Role 'Employee'
    "PayGradeId": 1, // Lowest Pay '$52,000'
    "PersonalInfoId": 3,
    "ScheduleId": 4
  }
 */
  [HttpPost]
  public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
  {
    if (ModelState.IsValid)
    {
      // Add the employee to the database
      _dbContext.Employee.Add(employee);
      await _dbContext.SaveChangesAsync();

      // Return the created employee with a 201 Created status
      return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
    }

    // Return a 400 Bad Request with validation errors if the model is not valid
    return BadRequest(ModelState);
  }


  /*
   * HTTP: GET
   * URL: /api/employees/{id}
   */
  [HttpGet("{id}")]
  public IActionResult GetEmployee(int id)
  {
    // Retrieve the employee by id
    var employee = _dbContext.Employee.Find(id);

    if (employee == null)
    {
      // Return a 404 Not Found if the employee is not found
      return NotFound();
    }

    // Return the employee with a 200 OK status
    return Ok(employee);
  }
}
